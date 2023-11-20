using System.Reflection;
using Conceptualizer.UnitTests.TestModel;
using FluentAssertions;

namespace Conceptualizer.UnitTests;

public class ModelDefinitionTests
{
    [Test]
    public void GivenModelDefined_ThenConceptsAndRelationsAreDefined()
    {
        // Given
        var model = Model.GetInstance();
        model.Initialize(Assembly.GetAssembly(typeof(EmployeeConcept))!);

        // Then
        var person = model.GetConcept<EmployeeConcept>();
        var employeeType = model.GetConcept<EmployeeTypeConcept>();

        person.Should().NotBeNull();
        employeeType.Should().NotBeNull();
        model.GetRelationships().Should().HaveCount(1);
    }
}