namespace Conceptualizer.Concepts;

public class ConceptAttribute
{
    private ConceptAttribute(string name, ConceptAttributeType type, bool isRequired)
    {
        Name = name;
        Type = type;
        IsRequired = isRequired;
    }

    public static ConceptAttribute Create(string name, ConceptAttributeType type, bool isRequired)
    {
        return new ConceptAttribute(name, type, isRequired);
    }

    public string Name { get; }
    
    public ConceptAttributeType Type { get; }
    
    public bool IsRequired { get; }
}