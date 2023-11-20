namespace Conceptualizer.Concepts;

public abstract class ConceptAttributeType
{
    public string Name { get; }

    protected ConceptAttributeType(string name)
    {
        Name = name;
    }
}