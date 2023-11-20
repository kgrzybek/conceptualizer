using Conceptualizer.Relationships;
using Conceptualizer.Relationships.Multiplicity;

namespace Conceptualizer.UnitTests.TestModel;

public class OrganizationStructureModel : RelationshipsModel
{
    public static void Create()
    {
        var model = Model.GetInstance();
        var employee = model.GetConcept<EmployeeConcept>();
        var organizationUnit = model.GetConcept<OrganizationUnitConcept>();
        
        model.AddRelationship(
            ConceptRelationship.Named(employee, "works for", new One(), organizationUnit),
            ConceptRelationship.Named(organizationUnit, "hires", new ZeroOrMany(), employee));
    }
}