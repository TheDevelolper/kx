
using Kx.Harness.AzureServiceBus.ServiceBus.Common;
using Kx.Harness.AzureServiceBus.Aggregates.Product.Events;

namespace Kx.Harness.AzureServiceBus;

public class ServiceBusTests: IClassFixture<ServiceBusTestFixture>
{
    private readonly ServiceBusTestFixture _fixture;

    public ServiceBusTests(ServiceBusTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Can_Send_Event_Message()
    {
        // arrange
        var envelope = new SystemEventEnvelope<ProductCreatedEvent>()
        {
            CorrelationId = Guid.CreateVersion7(),
            CausationId = Guid.CreateVersion7(),
            Event = new ProductCreatedEvent
            {
                Name = "Test Product",
                Price = 9.99m
            }
        };

        // act
        await _fixture.subject.SendMessagesAsync([envelope]);

        // assert
        Assert.True(true);
    }

    [Fact]
    public async Task Can_Receive_Event_Message()
    {
        // arrange
        var sendEnvelope = new SystemEventEnvelope<ProductCreatedEvent>()
        {
            CorrelationId = Guid.CreateVersion7(),
            CausationId = Guid.CreateVersion7(),
            Event = new ProductCreatedEvent
            {
                Name = "Test Product",
                Price = 9.99m
            }
        };

        SystemEventEnvelope<ProductCreatedEvent>[] sendMessages = [sendEnvelope];
        await _fixture.subject.SendMessagesAsync(sendMessages);

        // act
        using var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
        var cancellationToken = cancellationTokenSource.Token;

        var envelopes = _fixture.subject.ReceiveMessagesAsync<ProductCreatedEvent>(cancellationToken);

        // assert
        var envelopeCount = 0;

        await foreach (var envelope in envelopes)
        {
            Assert.Equal("Test Product", envelope.Event.Name);
            Assert.Equal(9.99m, envelope.Event.Price);

            envelopeCount++;

            if(envelopeCount == sendMessages.Length)
            {
                /*
                 * this also implicitly tests Assert.Equals(sendMessages.Length,envelopeCount);
                 * else there will be a timeout from the cancellation token which will throw exception.
                */
                break;
            }

        }
    }

}

public class ServiceBusTestFixture: IDisposable
{
    internal readonly IServiceBus subject;
    private readonly ServiceBusContainer serviceBusContainer;

    public ServiceBusTestFixture()
        {
        var serviceBusImageName = "mcr.microsoft.com/azure-messaging/servicebus-emulator:latest";
        var queueName = "queue.1";

        serviceBusContainer = new ServiceBusBuilder(serviceBusImageName)
            .WithName("azure-service-bus-emulator")
            .WithAcceptLicenseAgreement(true)
            .Build();

        serviceBusContainer.StartAsync().GetAwaiter().GetResult();

        var connectionString = serviceBusContainer.GetConnectionString();

        subject = new AzureServiceBusClient(
            new AzureServiceBusConfig(
                connectionString,
                queueName
        ));
    }

    public void Dispose()
        {
        serviceBusContainer.DisposeAsync().GetAwaiter().GetResult();
        GC.SuppressFinalize(this);
        }
    }
