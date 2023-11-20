using Conceptualizer.Concepts;

namespace Conceptualizer.UnitTests.TestModel;

public class EmployeeTypeConcept : EnumConcept
{
    public static EnumConcept Create() => new EmployeeTypeConcept()
        .WithName("Employee Type")
        .WithValues("Normal", "Manager");
}