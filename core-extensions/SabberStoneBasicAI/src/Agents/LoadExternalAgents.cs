using System;
using System.Linq;
using System.Reflection;

namespace SabberStoneBasicAI.Agents
{
    public static class FindAgents
    {
        private static Type[] GetAgentTypes()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Assembly[] assemblies = currentDomain.GetAssemblies();

            Type aiInterface = typeof(IAgent);

            Type[] agents = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => !type.IsInterface && 
                               !type.IsAbstract &&
                               type.GetInterfaces().Contains(aiInterface))
                .ToArray();

            return agents;
        }

        public static string[] Find()
        {
            Type[] types = GetAgentTypes();

            return types.Select(t => t.AssemblyQualifiedName).ToArray();
        }
    }
}
