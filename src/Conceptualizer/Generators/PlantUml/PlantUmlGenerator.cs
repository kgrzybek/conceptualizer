using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Conceptualizer.Concepts;
using Conceptualizer.Relationships;

namespace Conceptualizer.Generators.PlantUml;

public static class PlantUmlGenerator
{
    public static void Generate(
        string absoluteModelsPath,
        Model model,
        int indentSize,
        List<PlantUmlView> views)
    {
        foreach (var view in views)
        {
            var sb = new StringBuilder();

            sb.AppendLine("@startuml");
            sb.AppendLine();

            GenerateConcepts(sb, model, indentSize, view);

            GenerateRelationships(sb, model, view);
        
            sb.AppendLine();
            sb.AppendLine("@enduml");
            sb.AppendLine();

            var content = sb.ToString();
            
            var path = Path.Combine(absoluteModelsPath, view.Path);
            var directoryPath = Path.GetDirectoryName(path)!;

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            File.WriteAllText(path, content);
        }
    }

    private static void GenerateRelationships(StringBuilder sb, Model model, PlantUmlView view)
    {
        foreach (var biDirectionalConceptRelationship in model.GetRelationships())
        {
            if (view.Concepts.All(x => x.Concept != biDirectionalConceptRelationship.First.From) ||
                view.Concepts.All(x => x.Concept != biDirectionalConceptRelationship.First.To)) 
            {
                continue;
            }
            
            string relationshipType;

            if (biDirectionalConceptRelationship.First.Type is GeneralizationRelationshipType)
            {
                relationshipType = "--|>";
            }
            else
            {
                relationshipType = "-->";
            }

            string relationshipLabel = biDirectionalConceptRelationship.First.Name;
            if (!string.IsNullOrEmpty(biDirectionalConceptRelationship.Second.Name))
            {
                relationshipLabel = $"{relationshipLabel} / {biDirectionalConceptRelationship.Second.Name}";
            }
            
            sb.AppendLine(
                $"\"{biDirectionalConceptRelationship.First.From.Name}\" \"{biDirectionalConceptRelationship.Second.Multiplicity}" +
                $"\" {relationshipType} \"{biDirectionalConceptRelationship.First.Multiplicity}\" \"{biDirectionalConceptRelationship.First.To.Name}\" : \"{relationshipLabel}\" ");
        }
    }

    private static void GenerateConcepts(
        StringBuilder sb,
        Model model,
        int indentSize,
        PlantUmlView view)
    {
        var indent = string.Empty;
        for (int i = 0; i < indentSize; i++)
        {
            indent += " ";
        }
        
        foreach (var concept in model.GetConcepts().OrderBy(x => x.Name))
        {
            var viewConcept = view.Concepts.SingleOrDefault(x => x.Concept == concept);
            if (viewConcept == null)
            {
                continue;
            }

            if (concept is EntityConcept entityConcept)
            {
                GenerateConcept(sb, entityConcept, viewConcept, indent);
                sb.AppendLine();
            }
            
            if (concept is EnumConcept enumConcept)
            {
                GenerateEnumConcept(sb, enumConcept, viewConcept, indent);
                sb.AppendLine();
            }
        }
    }

    private static void GenerateConcept(
        StringBuilder sb,
        EntityConcept concept,
        VisibleConcept viewConcept,
        string indent)
    {
        sb.AppendLine($"entity \"{concept.Name}\"" + " {");
            
        if (viewConcept.ShowAttributes)
        {
            foreach (var attribute in concept.Attributes.OrderBy(x => x.Name))
            {
                var isRequiredString = attribute.IsRequired ? string.Empty : " [0..1]";
                sb.AppendLine($"{indent}{attribute.Name}: {attribute.Type.Name}{isRequiredString}");
            }
        }

        sb.AppendLine("}");
    }
    
    private static void GenerateEnumConcept(
        StringBuilder sb,
        EnumConcept concept,
        VisibleConcept viewConcept,
        string indent)
    {
        sb.AppendLine($"enum \"{concept.Name}\"" + " {");
            
        if (viewConcept.ShowAttributes)
        {
            foreach (var value in concept.Values.OrderBy(x => x))
            {
                sb.AppendLine($"{indent}{value}");
            }
        }

        sb.AppendLine("}");
    }
}