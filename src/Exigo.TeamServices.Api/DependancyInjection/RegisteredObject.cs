using System;

namespace Exigo.TeamServices.Api.DependancyInjection
{
    internal class RegisteredObject
    {
        internal readonly object[] Parameters;
        internal Type TypeToResolve { get; }

        internal Type ConcreteType { get; }

        internal object Instance { get; private set; }

        internal Func<object> Initialization { get; set; }

        internal LifeCycle LifeCycle { get; }

        internal RegisteredObject(Type typeToResolve, Type concreteType, LifeCycle lifeCycle, Func<object> init)
            : this(typeToResolve, concreteType, lifeCycle)
        {
            Initialization = init;
        }

        internal RegisteredObject(Type typeToResolve, Type concreteType, LifeCycle lifeCycle)
        {
            TypeToResolve = typeToResolve;
            ConcreteType = concreteType;
            LifeCycle = lifeCycle;
        }

        public RegisteredObject(Type typeToResolve, Type concreteType, LifeCycle lifeCycle, object[] parameters)
            : this(typeToResolve, concreteType, lifeCycle)
        {
            Parameters = parameters;
        }

        internal void CreateInstance()
            => Instance = Initialization == null? Activator.CreateInstance(ConcreteType) : Initialization.Invoke();
    }
}