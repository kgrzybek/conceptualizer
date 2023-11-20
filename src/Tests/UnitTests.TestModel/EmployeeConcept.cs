using Conceptualizer.Concepts;
using Conceptualizer.UnitTests.TestModel.AttributeTypes;

namespace Conceptualizer.UnitTests.TestModel;

public class EmployeeConcept : EntityConcept
{
    public static EntityConcept Create() => new EmployeeConcept()
        .WithName("Employee")
        .WithAttribute("FirstName", new Text())
        .WithAttribute("LastName", new Text());
}