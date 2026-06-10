using Microsoft.Extensions.DependencyInjection;

namespace Kx.Shared.Application.Contracts;

public interface IFeatureModule
{
    /// <summary>
    /// Registers the services for the module. This method will be called during application startup to add the module's services to the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    IServiceCollection RegisterServices(IServiceCollection services);

    /// <summary>
    /// Defines the endpoints for the module. This method will be called during application startup to map the module's endpoints.
    /// </summary>
    /// <param name="endpoints"></param>
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}

