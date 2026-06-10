using System.Runtime.CompilerServices;
using System.Text.Json;

using Azure.Messaging.ServiceBus;
using Kx.Harness.AzureServiceBus.ServiceBus.Common;

namespace Kx.Harness.AzureServiceBus.ServiceBus.Azure;

internal class AzureServiceBusClient : IServiceBus
{
    private readonly ServiceBusClient _azureServiceBusClient;
    private readonly ServiceBusSender _azureServiceBusSender;

    public AzureServiceBusClient(AzureServiceBusConfig config)
    {
        _azureServiceBusClient = new ServiceBusClient(config.ConnectionString);
        _azureServiceBusSender = _azureServiceBusClient.CreateSender(config.QueueName);
    }

    public async Task SendMessagesAsync<TSystemEvent>(SystemEventEnvelope<TSystemEvent>[] envolopes) where TSystemEvent : SystemEvent
    {
        var messages = envolopes.Select(
            envelope => new ServiceBusMessage(JsonSerializer.Serialize(envelope))
        );

        await _azureServiceBusSender.SendMessagesAsync(messages);
    }

    public async IAsyncEnumerable<SystemEventEnvelope<TSystemEvent>> ReceiveMessagesAsync<TSystemEvent>([EnumeratorCancellation] CancellationToken cancellationToken) where TSystemEvent : SystemEvent
    {
        var receiver = _azureServiceBusClient.CreateReceiver("queue.1");

        await foreach (var message in receiver.ReceiveMessagesAsync(cancellationToken))
        {
            await receiver.CompleteMessageAsync(message, cancellationToken);

            yield return JsonSerializer.Deserialize<SystemEventEnvelope<TSystemEvent>>(message.Body) ??
            throw new InvalidOperationException($"Message payload could not be deserialized as {typeof(TSystemEvent).FullName}.");
        }
    }
}
