using Conceptualizer.Concepts;

namespace Conceptualizer.Relationships;

public class ConceptRelationship
{
    private ConceptRelationship(
        Concept from,
        string name,
        RelationshipMultiplicity fromSourceToDestination,
        Concept to,
        RelationshipType type)
    {
        From = from;
        To = to;
        Name = name;
        Multiplicity = fromSourceToDestination;
        Type = type;
    }

    public Concept From { get; }
    
    public Concept To { get; }
    
    public string Name { get; }
    
    public RelationshipMultiplicity Multiplicity { get; }
    
    public RelationshipType Type { get; }
    
    public static ConceptRelationship Named(
        Concept from,
        string name,
        RelationshipMultiplicity multiplicity,
        Concept to,
        RelationshipType? type = null)
    {
        var relationshipType = type ?? new AssociationRelationshipType();
        
        return new ConceptRelationship(from, name, multiplicity, to, relationshipType);
    }
    
    public static ConceptRelationship Unnamed(
        Concept from,
        RelationshipMultiplicity multiplicity,
        Concept to,
        RelationshipType? type = null)
    {
        var relationshipType = type ?? new AssociationRelationshipType();
        
        return new ConceptRelationship(from, string.Empty, multiplicity, to, relationshipType);
    }
}

public abstract class RelationshipType
{
}

public class AssociationRelationshipType : RelationshipType
{
    
}

public class GeneralizationRelationshipType : RelationshipType
{
    
}