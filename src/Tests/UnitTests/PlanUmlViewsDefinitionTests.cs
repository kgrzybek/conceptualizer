using System.Reflection;
using Conceptualizer.UnitTests.TestModel;
using FluentAssertions;

namespace Conceptualizer.UnitTests;

public class PlanUmlViewsDefinitionTests
{
    [Test]
    public void GivenModelDefinedAndViewsDefined_ThenViewsAreReturned()
    {
        // Given
        var model = Model.GetInstance();
        model.Initialize(Assembly.GetAssembly(typeof(EmployeeConcept))!);
        
        var viewsFactory = PlantUmlModelViewsFactory.GetInstance();
        viewsFactory.Initialize(Assembly.GetAssembly(typeof(OrganizationStructureView))!);

        // Then
        viewsFactory.Views.Should().HaveCount(1);
    }
}