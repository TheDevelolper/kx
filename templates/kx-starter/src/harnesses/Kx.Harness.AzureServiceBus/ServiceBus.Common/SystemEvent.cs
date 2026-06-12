namespace Kx.Harness.AzureServiceBus.ServiceBus.Common;

/// <summary>
/// Base record for all system events
/// </summary>
internal abstract record SystemEvent
{
    /// <summary>
    /// Unique identifier for the system event
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Timestamp indicating when the event occurred in UTC
    /// </summary>
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
}
