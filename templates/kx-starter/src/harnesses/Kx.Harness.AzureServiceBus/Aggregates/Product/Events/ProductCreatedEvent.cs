using Kx.Harness.AzureServiceBus.ServiceBus.Common;

namespace Kx.Harness.AzureServiceBus.Aggregates.Product.Events;

/// <summary>
/// Event representing the creation of a product
/// </summary>
internal record ProductCreatedEvent : SystemEvent
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}
