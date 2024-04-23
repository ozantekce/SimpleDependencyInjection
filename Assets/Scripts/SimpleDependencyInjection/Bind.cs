using System;

namespace SimpleDependencyInjection
{
    /// <summary>
    /// Represents a binding for dependency injection, encapsulating the type, an optional alias, and the instance of the object.
    /// </summary>
    public struct Bind
    {
        /// <summary>
        /// The type of the object being bound.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// An optional alias for identifying different instances of the same type.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// The instance of the object that is bound to the specified type and alias.
        /// </summary>
        public object Instance { get; set; }

        /// <summary>
        /// Constructs a new bind configuration.
        /// </summary>
        /// <param name="type">The type of the object to bind.</param>
        /// <param name="alias">An alias to differentiate this binding from others of the same type.</param>
        /// <param name="instance">The instance of the object that this binding represents.</param>
        public Bind(Type type, string alias, object instance)
        {
            Type = type;
            Alias = alias;
            Instance = instance;
        }
    }
}
