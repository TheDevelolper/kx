namespace Kx.Architecture.Tests.Helpers;

internal class ModuleServiceDiscovery
{
    internal static IModule GetModules()
    {
        return new Module();
    }
}

internal class Module : IModule
{
    // Implement properties or methods that represent a module
}

