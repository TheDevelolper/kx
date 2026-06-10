
using Kx.Harness.AzureServiceBus.ServiceBus.Common;
using Kx.Harness.AzureServiceBus.ServiceBus.Azure;

using Testcontainers.ServiceBus;

namespace Kx.Harness.AzureServiceBus;

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
