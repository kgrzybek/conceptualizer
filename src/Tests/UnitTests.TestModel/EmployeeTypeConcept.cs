using Conceptualizer.Concepts;

namespace Conceptualizer.UnitTests.TestModel;

public class EmployeeTypeConcept : EnumConcept
{
    public static EnumConcept Create() => new EmployeeTypeConcept()
        .WithValues("Normal", "Manager");
}