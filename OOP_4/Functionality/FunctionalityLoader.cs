using System.Reflection;
using BaseShapesClasses;

namespace OOP_3.Functionality;

public class FunctionalityLoader
{
    public IFunctionality LoadNewFunctionality(string path)
    {
        if (path != null)
        {
            Assembly pluginAssembly = Assembly.LoadFrom(path);
            Type[] types = pluginAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (typeof(IFunctionality).IsAssignableFrom(type))
                {
                    if (Activator.CreateInstance(type) is IFunctionality pluginFunctionality)
                        return pluginFunctionality;
                }
            }
        }
        return null;
    }
}
