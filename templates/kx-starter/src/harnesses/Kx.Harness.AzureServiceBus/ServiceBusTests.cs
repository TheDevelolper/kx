
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
            MessageId = Guid.CreateVersion7(),
            CorrelationId = Guid.CreateVersion7(),
            CausationId = Guid.CreateVersion7(),
            Event = new ProductCreatedEvent
            {
                Id = Guid.CreateVersion7(),
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
        var correlationId = Guid.CreateVersion7();
        var causationId = Guid.CreateVersion7();
        var messageId = Guid.CreateVersion7();
        var eventId = Guid.CreateVersion7();

        var productName = "Test Product";
        var productPrice = 9.99m;

        var sendEnvelope = new SystemEventEnvelope<ProductCreatedEvent>()
        {
            MessageId = messageId,
            CorrelationId = correlationId,
            CausationId = causationId,
            Event = new ProductCreatedEvent
            {
                Id = eventId,
                Name = productName,
                Price = productPrice
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

        await foreach (var envelope in envelopes)
        {
            if(eventId != envelope.Event.Id)
            {
                continue;
            }

            Assert.Equal(eventId, envelope.Event.Id);
            Assert.Equal(typeof(SystemEventEnvelope<ProductCreatedEvent>), envelope.GetType());

            Assert.Equal(productName, envelope.Event.Name);
            Assert.Equal(productPrice, envelope.Event.Price);
            Assert.Equal(messageId, envelope.MessageId);
            Assert.Equal(causationId, envelope.CausationId);
            Assert.Equal(correlationId, envelope.CorrelationId);

            break;
        }
    }
}

