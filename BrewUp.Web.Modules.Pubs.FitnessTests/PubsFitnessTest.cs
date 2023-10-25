using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using BrewUp.Web.Modules.Pubs.Extensions.Abstracts;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace BrewUp.Web.Modules.Pubs.FitnessTests;

public class PubsFitnessTest
{
    private static readonly Architecture Architecture = new ArchLoader().LoadAssemblies(typeof(IBeerService).Assembly).Build();

    private readonly IObjectProvider<IType> _forbiddenLayer = Types().
        That().
        ResideInNamespace("BrewUp.Web.Modules.Production").
        As("Forbidden Layer");

    private readonly IObjectProvider<Interface> _forbiddenInterfaces = Interfaces().
        That().
        HaveFullNameContaining("Production").
        As("Forbidden Interfaces");

    [Fact]
    public void PubsTypesShouldBeInCorrectLayer()
    {
        IArchRule forbiddenInterfacesShouldBeInForbiddenLayer =
            Interfaces().That().Are(_forbiddenInterfaces).Should().Be(_forbiddenLayer);

        forbiddenInterfacesShouldBeInForbiddenLayer.Check(Architecture);
    }
}