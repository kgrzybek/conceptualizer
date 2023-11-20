using Conceptualizer.Generators;
using Conceptualizer.Generators.PlantUml;

namespace Conceptualizer.UnitTests.TestModel;

public class OrganizationStructureView : PlantUmlViewFactory
{
    public static PlantUmlView Create()
    {
        var concepts = new List<VisibleConcept>();

        var model = Model.GetInstance();
        
        concepts.Add(new VisibleConcept(model.GetConcept<EmployeeConcept>()));
        concepts.Add(new VisibleConcept(model.GetConcept<EmployeeTypeConcept>()));
        concepts.Add(new VisibleConcept(model.GetConcept<OrganizationUnitConcept>()));
        
        var view = new PlantUmlView(concepts, "OrganizationStructure.puml");

        return view;
    }
}