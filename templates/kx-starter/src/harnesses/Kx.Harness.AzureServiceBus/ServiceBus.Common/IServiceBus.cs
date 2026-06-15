namespace Kx.Harness.AzureServiceBus.ServiceBus.Common;

internal interface IServiceBus
{
    /// <summary>
    /// Sends an array of system event envelopes to the service bus. Each envelope contains a system event along with correlation and causation IDs for tracing. The method is asynchronous and returns a Task that completes when the messages have been sent. The generic type parameter TSystemEvent is constrained to be a subtype of SystemEvent, ensuring that only valid system events can be sent through the service bus.
    /// </summary>
    /// <typeparam name="TSystemEvent">
    /// The type of the system event being sent, constrained to be a subtype of SystemEvent. This allows for type safety and ensures that only valid system events can be sent through the service bus.
    /// </typeparam>
    /// <param name="envolopes">
    /// An array of SystemEventEnvelope objects, where each envelope contains a system event of type TSystemEvent along with correlation and causation IDs for tracing. This allows for sending multiple events in a single batch to the service bus.
    /// </param>
    /// <returns>
    /// A Task that represents the asynchronous operation of sending messages to the service bus. The Task completes when all messages have been sent successfully. If an error occurs during the sending process, the Task will be faulted with the appropriate exception.
    /// </returns>
    Task SendMessagesAsync<TSystemEvent>(SystemEventEnvelope<TSystemEvent>[] envolopes) where TSystemEvent : SystemEvent;

     /// <summary>
    /// Sends an array of system event envelopes to the service bus, where each envelope contains a system event along with correlation and causation IDs for tracing. The method is asynchronous and returns a Task that completes when the messages have been sent.
    /// </summary>
    /// <typeparam name="TSystemEvent">
    /// The type of the system event being sent, constrained to be a subtype of SystemEvent. This allows the method to be flexible and work with any specific type of system event while ensuring that it adheres to the structure defined by the SystemEvent base record.
    /// </typeparam>
    /// <returns>
    /// A Task that represents the asynchronous operation of sending messages to the service bus. The Task completes when all messages have been sent successfully, allowing the caller to await this operation and handle any exceptions that may occur during the sending process.
    ///  </returns>
    IAsyncEnumerable<SystemEventEnvelope<TSystemEvent>> ReceiveMessagesAsync<TSystemEvent>(CancellationToken cancellationToken) where TSystemEvent : SystemEvent;
}

