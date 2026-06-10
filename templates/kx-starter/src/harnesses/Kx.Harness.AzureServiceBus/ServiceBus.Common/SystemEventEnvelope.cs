namespace Kx.Harness.AzureServiceBus.ServiceBus.Common;

/// <summary>
/// Wrapper for system events to be sent through the service bus, including correlation and
/// causation IDs for tracing
/// </summary>
/// <typeparam name="TEvent">
/// The type of the system event being wrapped, constrained to be a subtype of SystemEvent
/// </typeparam>
internal class SystemEventEnvelope<TEvent> where TEvent : SystemEvent
{
    /// <summary>
    /// The actual system event being wrapped, containing the details of the event such as its type, timestamp, and unique identifier. This allows the event to be transmitted through the service bus while maintaining its original structure and information.
    /// </summary>
    public required TEvent Event { get; init; }

    /// <summary>
    /// Groups related messages together for tracing across distributed systems, allowing you to see all messages that are part of the same workflow or transaction. This is especially useful for debugging and monitoring complex interactions between services.
    /// </summary>
    public required Guid CorrelationId { get; init; } = Guid.CreateVersion7();

    /// <summary>
    /// Identifies the specific cause of the event, such as a user action or another event that triggered this event. This helps in understanding the chain of events and their relationships, making it easier to trace back to the root cause of an issue or to analyze the flow of events in a system.
    /// </summary>
    public required Guid CausationId { get; init; } = Guid.CreateVersion7();
}

