using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Conceptualizer.Generators.PlantUml;

namespace Conceptualizer;

public class PlantUmlModelViewsFactory
{
    private static PlantUmlModelViewsFactory? _instance;

    public void Initialize(Assembly modelAssembly)
    {
        InitializeViews(modelAssembly);
    }

    private void InitializeViews(Assembly modelAssembly)
    {
        var types = modelAssembly
            .GetTypes()
            .Where(t =>
                typeof(PlantUmlViewFactory).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, null);
                Views.Add((PlantUmlView) plantUmlView!);
            }
        }
    }

    private PlantUmlModelViewsFactory()
    {
        Views = new List<PlantUmlView>();
    }

    public List<PlantUmlView> Views { get; }

    public static PlantUmlModelViewsFactory GetInstance()
    {
        if (_instance == null)
        {
            if (_instance == null)
            {
                _instance = new PlantUmlModelViewsFactory();
            }
        }

        return _instance;
    }
}