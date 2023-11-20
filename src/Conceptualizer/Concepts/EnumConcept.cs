using System.Collections.Generic;
using System.Linq;

namespace Conceptualizer.Concepts;

public class EnumConcept : Concept
{
    public List<string> Values { get; private set; }

    protected EnumConcept()
    {
        Values = new List<string>();
    }
    
    protected EnumConcept WithName(
        string name)
    {
        this.Name = name;

        return this;
    }

    protected EnumConcept WithValues(params string[] values)
    {
        Values = values.ToList();

        return this;
    }
}