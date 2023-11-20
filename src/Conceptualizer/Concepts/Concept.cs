using System;

namespace Conceptualizer.Concepts;

public abstract class Concept
{
    protected Concept(string name)
    {
        Name = name;
    }

    protected Concept()
    {
        var name = this.GetType().Name;
        this.Name = name.Substring(0, name.Length - 7);
    }

    public string Name { get; protected set; }

    public override bool Equals(object? obj)
    {
        return obj?.GetType() == this.GetType();
    }

    protected bool Equals(Concept other)
    {
        return other?.GetType() == this.GetType();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return this.GetType().Name;
    }
}