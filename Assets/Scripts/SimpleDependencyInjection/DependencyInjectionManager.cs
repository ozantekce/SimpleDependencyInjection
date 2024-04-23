using System;
using System.Collections.Generic;

namespace SimpleDependencyInjection
{
    /// <summary>
    /// Provides a simple implementation of a dependency injection manager to manage bindings and resolve dependencies.
    /// </summary>
    public static class DependencyInjectionManager
    {
        /// <summary>
        /// Stores all bindings grouped by type and optionally by alias.
        /// </summary>
        private static readonly Dictionary<Type, Dictionary<string, Bind>> Injectables = new Dictionary<Type, Dictionary<string, Bind>>();

        /// <summary>
        /// Adds a binding to the manager.
        /// </summary>
        /// <param name="bind">The binding configuration containing the type, alias, and instance.</param>
        public static void AddBind(Bind bind)
        {
            Type type = bind.Type;
            string alias = bind.Alias ?? string.Empty;

            // Ensure there is a subdictionary for the type
            if (!Injectables.ContainsKey(type))
            {
                Injectables[type] = new Dictionary<string, Bind>();
            }

            // Add or replace the binding in the subdictionary
            Injectables[type][alias] = bind;
        }

        /// <summary>
        /// Removes a specific binding from the manager.
        /// </summary>
        /// <param name="bind">The binding to remove, specified by type and optional alias.</param>
        public static void RemoveBind(Bind bind)
        {
            Type type = bind.Type;
            string alias = bind.Alias ?? string.Empty;

            // Try to get the subdictionary and remove the binding if found
            if (Injectables.TryGetValue(type, out var subDictionary))
            {
                subDictionary.Remove(alias);

                // If no more bindings exist for the type, remove the subdictionary
                if (subDictionary.Count == 0)
                {
                    Injectables.Remove(type);
                }
            }
        }

        /// <summary>
        /// Overloaded method to remove a binding by type and optional alias.
        /// </summary>
        /// <param name="type">The type of the binding to remove.</param>
        /// <param name="alias">The alias of the binding to remove (defaults to empty string if null).</param>
        public static void RemoveBind(Type type, string alias = null)
        {
            alias ??= string.Empty;

            // Try to get the subdictionary and remove the binding if found
            if (Injectables.TryGetValue(type, out var subDictionary))
            {
                subDictionary.Remove(alias);

                // If no more bindings exist for the type, remove the subdictionary
                if (subDictionary.Count == 0)
                {
                    Injectables.Remove(type);
                }
            }
        }

        /// <summary>
        /// Retrieves an instance of the specified type and alias from the bindings.
        /// </summary>
        /// <typeparam name="T">The type of instance to retrieve.</typeparam>
        /// <param name="alias">The alias of the binding to retrieve (defaults to empty string if null).</param>
        /// <returns>The instance of type T if found; otherwise, returns the default value of type T.</returns>
        public static T Get<T>(string alias = null)
        {
            alias ??= string.Empty;

            Type type = typeof(T);
            // Attempt to retrieve the instance from the subdictionary
            if (Injectables.TryGetValue(type, out var subDic))
            {
                if (subDic.TryGetValue(alias, out Bind bind))
                {
                    return (T)bind.Instance;
                }
            }

            // Return the default value if the binding is not found
            return default;
        }
    }
}
