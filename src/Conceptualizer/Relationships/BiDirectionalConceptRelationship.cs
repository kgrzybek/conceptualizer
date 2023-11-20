namespace Conceptualizer.Relationships;

public class BiDirectionalConceptRelationship
{
    public BiDirectionalConceptRelationship(
        ConceptRelationship first,
        ConceptRelationship second,
        string? relationshipCode = null)
    {
        First = first;
        Second = second;
        RelationshipCode = relationshipCode;
    }

    public ConceptRelationship First { get; }
    
    public ConceptRelationship Second { get; }
    
    public string? RelationshipCode { get; }
}