namespace Kx.Harness.AzureServiceBus.ServiceBus.Common;

/// <summary>
/// Base record for all system events
/// </summary>
internal abstract record SystemEvent
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
}

