using System.Reflection;

using Exigo.TeamServices.Data.Repository.Base;

using Ninject;

namespace Exigo.TeamServices.Data.IoC
{
    public class RepositoryContainer : IRepositoryContainer
    {
        private StandardKernel _kernal;
        public static RepositoryContainer DefaultContainer { get; private set; }

        private RepositoryContainer()
        {
            RegisterComponents();
        }

        /// <inheritdoc />
        public TRepository FethInstance<TRepository>() where TRepository : IRepository
        {
            return (DefaultContainer ?? (DefaultContainer = new RepositoryContainer()))._kernal.Get<TRepository>();
        }

        /// <inheritdoc />
        public void RegisterComponents()
        {
            _kernal = new StandardKernel();
            _kernal.Load(Assembly.GetExecutingAssembly());
        }
    }

    public interface IRepositoryContainer
    {
        TRepository FethInstance<TRepository>() where TRepository : IRepository;
    }
}