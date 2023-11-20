using System.Collections.Generic;

namespace Conceptualizer.Generators.PlantUml;

public class PlantUmlView
{
    public PlantUmlView(List<VisibleConcept> concepts, string path)
    {
        Concepts = concepts;
        Path = path;
    }

    public List<VisibleConcept> Concepts { get; }
    
    public string Path { get; }
}