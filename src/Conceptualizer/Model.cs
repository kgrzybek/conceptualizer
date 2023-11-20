using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Conceptualizer.Concepts;
using Conceptualizer.Relationships;

namespace Conceptualizer;

public class Model
{
    private static Model? _instance;

    public void Initialize(Assembly modelAssembly)
    {
        _concepts = new List<Concept>();
        _relationships = new List<BiDirectionalConceptRelationship>();
        InitializeEnums(modelAssembly);
        InitializeEntities(modelAssembly);
        InitializeModels(modelAssembly);
    }

    private void InitializeEnums(Assembly modelAssembly)
    {
        var types = modelAssembly
            .GetTypes()
            .Where(t =>
                typeof(EnumConcept).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var concept = staticMethod.Invoke(null, null);
                _concepts.Add((Concept) concept!);
            }
        }
    }

    private void InitializeEntities(Assembly modelAssembly)
    {
        var types = modelAssembly
            .GetTypes()
            .Where(t =>
                typeof(EntityConcept).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var concept = staticMethod.Invoke(null, null);
                _concepts.Add((Concept) concept!);
            }
        }
    }

    private void InitializeModels(Assembly modelAssembly)
    {
        var types = modelAssembly
            .GetTypes()
            .Where(t =>
                typeof(RelationshipsModel).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                staticMethod.Invoke(null, null);
            }
        }
    }

    private Model()
    {
        _concepts = new List<Concept>();
        _relationships = new List<BiDirectionalConceptRelationship>();
    }

    private List<Concept> _concepts;

    private List<BiDirectionalConceptRelationship> _relationships;

    public T GetConcept<T>()
        where T : Concept
    {
        var concept = _concepts.OfType<T>().SingleOrDefault();

        if (concept == null)
        {
            throw new Exception($"Concept {typeof(T)} is not defined in the model");
        }

        return concept;
    }

    public void AddRelationship(
        ConceptRelationship first,
        ConceptRelationship second,
        string? relationshipCode = null)
    {
        _relationships.Add(new BiDirectionalConceptRelationship(
            first,
            second,
            relationshipCode));
    }

    public static Model GetInstance()
    {
        if (_instance == null)
        {
            if (_instance == null)
            {
                _instance = new Model();
            }
        }

        return _instance;
    }

    public List<BiDirectionalConceptRelationship> GetRelationships() => _relationships.ToList();
    public List<Concept> GetConcepts() => _concepts.ToList();
}