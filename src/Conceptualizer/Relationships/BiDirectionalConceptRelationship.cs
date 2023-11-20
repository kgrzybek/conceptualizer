namespace Conceptualizer.Relationships;

public class BiDirectionalConceptRelationship
{
    public BiDirectionalConceptRelationship(ConceptRelationship first, ConceptRelationship second)
    {
        First = first;
        Second = second;
    }

    public ConceptRelationship First { get; }
    
    public ConceptRelationship Second { get; }
}