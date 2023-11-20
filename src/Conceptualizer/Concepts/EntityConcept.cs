using System.Collections.Generic;

namespace Conceptualizer.Concepts;

public abstract class EntityConcept : Concept
{
    public List<ConceptAttribute> Attributes { get; }

    protected EntityConcept()
    {
        Attributes = new List<ConceptAttribute>();
    }

    public EntityConcept WithAttribute(
        string name,
        ConceptAttributeType type,
        bool isRequired = true)
    {
        Attributes.Add(ConceptAttribute.Create(name, type, isRequired));

        return this;
    }

    protected EntityConcept WithName(
        string name)
    {
        this.Name = name;

        return this;
    }
}