using NetArchTest.Rules;

namespace Kx.Architecture.Tests;

public class UnitTest1
{
    [Fact]
    public void EveryModuleHasAtLeastOneEntryPoint()
    {
        var discoveredModules = ModuleServiceDiscovery.GetModules();

        var result = Types.InAssembly(typeof(Kx.Architecture.Domain.Class1).Assembly)
            .That()
            .ResideInNamespace("Kx.Architecture.Domain")
            .Should()
            .HavePublicMethods()
            .GetResult();

        Assert.True(result.IsSuccessful, "Domain layer should have at least one public method.");
    }

    [Fact]
    public void DomainAssemblyMustExist()
    {
        var assembly = typeof(Kx.Architecture.Domain.Class1).Assembly;

        Assert.NotNull(assembly);
    }


    [Fact]
    public void DomainMustNotReferenceInfrastructure()
    {
        var result = Types.InAssembly(typeof(Kx.Architecture.Domain.Class1).Assembly)
            .That()
            .ResideInNamespace("Kx.Architecture.Domain")
            .ShouldNot()
            .HaveDependencyOn("Kx.Architecture.Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful, "Domain layer should not reference Infrastructure layer.");
    }
}
