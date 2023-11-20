using System.Collections.Generic;

namespace Conceptualizer.Generators.PlantUml;

public class PlantUmlView
{
    public PlantUmlView(
        List<VisibleConcept> concepts,
        string path, 
        List<RelationshipNote>? relationshipNotes = null)
    {
        Concepts = concepts;
        Path = path;
        RelationshipNotes = relationshipNotes ?? new List<RelationshipNote>();
    }

    public List<VisibleConcept> Concepts { get; }
    
    public List<RelationshipNote> RelationshipNotes { get; }

    public string Path { get; }
}