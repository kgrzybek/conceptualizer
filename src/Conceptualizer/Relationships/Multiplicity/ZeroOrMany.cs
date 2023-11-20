namespace Conceptualizer.Relationships.Multiplicity;

public class ZeroOrMany : RelationshipMultiplicity
{
    public override string ToString()
    {
        return "0..*";
    }
}