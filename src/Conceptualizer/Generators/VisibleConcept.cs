using Conceptualizer.Concepts;

namespace Conceptualizer.Generators;

public class VisibleConcept
{
    public VisibleConcept(Concept concept, bool showAttributes = true)
    {
        Concept = concept;
        ShowAttributes = showAttributes;
    }

    public Concept Concept { get; } 
    
    public bool ShowAttributes { get; }
}