// ReSharper disable VirtualMemberCallInConstructor

using System;
using System.Collections.Generic;
using System.Linq;

namespace Exigo.TeamServices.Api.DependancyInjection
{
    public interface IIocContainer
    {
        object FetchInstance(Type @interface);
        TInterface FetchInstance<TInterface>();

        void OverrideRegistration<TInterface, TConcrete>(LifeCycle lifeCycle, Func<TConcrete> initialization)
            where TConcrete : class;

        void Register();
        void Register<TInterface, TConcrete>() where TConcrete : class;
        void Register<TInterface, TConcrete>(LifeCycle lifeCycle) where TConcrete : class;
        void Register<TInterface, TConcrete>(Func<TConcrete> initialization) where TConcrete : class;
    }

    public abstract class IocContainer : IIocContainer
    {
        private readonly HashSet<Type> _registeredInterfaces = new HashSet<Type>();
        private readonly HashSet<RegisteredObject> _registeredObjects = new HashSet<RegisteredObject>();

        protected IocContainer()
        {
            Register();
        }

        public void Register<TInterface, TConcrete>() where TConcrete : class
            => Register<TInterface, TConcrete>(null);

        public void Register<TInterface, TConcrete>(LifeCycle lifeCycle) where TConcrete : class
            => Register<TInterface, TConcrete>(LifeCycle.Singleton, null);

        public TInterface FetchInstance<TInterface>()
            => (TInterface) FetchObject(typeof(TInterface));

        public object FetchInstance(Type @interface)
            => FetchObject(@interface);

        public abstract void Register();

        public virtual void Register<TInterface, TConcrete>(Func<TConcrete> initialization) where TConcrete : class
            => Register<TInterface, TConcrete>(LifeCycle.Singleton, initialization);

        /// <summary>
        ///     Overrides the registration of <see cref="TInterface" /> in the container.
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <typeparam name="TConcrete">The type of the t @interface.</typeparam>
        /// <param name="lifeCycle">The life cycle.</param>
        /// <param name="initialization">The initialization.</param>
        /// <exception cref="System.InvalidOperationException">
        ///     If the interface you're trying to force register is not registered,
        ///     please use one of the 'Register' methods
        /// </exception>
        public void OverrideRegistration<TInterface, TConcrete>(LifeCycle lifeCycle, Func<TConcrete> initialization)
            where TConcrete : class
        {
            try
            {
                var regObj = FetchRegisteredObject(typeof(TInterface));
                _registeredObjects.Remove(regObj);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException(
                    "The interface you're trying to force registration on is not registered, please use one of the 'Register' methods");
            }

            ForceRegistration<TInterface, TConcrete>(lifeCycle, initialization);
        }

        protected bool IsRegistered<TInterface>()
            => _registeredInterfaces.Contains(typeof(TInterface));

        private void ForceRegistration<TInterface, TConcrete>(LifeCycle lifeCycle, Func<TConcrete> initialization)
            where TConcrete : class
            => Register<TInterface, TConcrete>(lifeCycle, initialization, true);

        private RegisteredObject FetchRegisteredObject(Type interfaceType)
            => _registeredObjects.First(obj => obj.TypeToResolve == interfaceType);

        protected void Register<TInterface, TConcrete>(LifeCycle lifeCycle, Func<TConcrete> initialization,
                                                       bool forced = false) where TConcrete : class
        {
            if (IsRegistered<TInterface>() && !forced)
                throw new InvalidOperationException(
                    $"{typeof(TInterface)} has already been registerd. If you intentionally tried to register a type to this interface then please use the 'OverrideRegistration' method");

            _registeredInterfaces.Add(typeof(TInterface));
            _registeredObjects.Add(new RegisteredObject(typeof(TInterface), typeof(TConcrete), LifeCycle.Singleton,
                initialization));
        }

        private object FetchObject(Type @interface)
        {
            var registeredObject = _registeredObjects.FirstOrDefault(o => o.TypeToResolve == @interface);
            if (registeredObject == null)
                throw new TypeNotRegisteredException($"The type {@interface.Name} has not been registered");

            return GetInstance(registeredObject);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            if (registeredObject.Instance != null && registeredObject.LifeCycle != LifeCycle.Transient) return registeredObject.Instance;

            registeredObject.CreateInstance();
            return registeredObject.Instance;
        }

        private IEnumerable<object> FetchConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters()) yield return FetchObject(parameter.ParameterType);
        }
    }
}