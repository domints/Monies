using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Monies.Terminal.Screens;

namespace Monies.Terminal.Helpers
{
    public static class ScreenRegisterer
    {
        public static void AddScreens(this ServiceCollection services)
        {
            var iScreenType = typeof(IScreen);
            var screens = GetTypesInNamespace(iScreenType.Assembly, iScreenType.Namespace)
                .Where(t => t.IsClass && !t.IsAbstract && iScreenType.IsAssignableFrom(t));
            
            foreach(var screenType in screens)
            {
                services.AddTransient(screenType);
            }
        }

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => t.Namespace.StartsWith(nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }
    }
}