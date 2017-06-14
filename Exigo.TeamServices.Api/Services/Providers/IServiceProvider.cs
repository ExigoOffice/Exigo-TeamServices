using Exigo.TeamServices.Api.DependancyInjection;
using Exigo.TeamServices.Api.Handlers;

namespace Exigo.TeamServices.Api.Services.Providers
{
    /// <summary>
    ///     Interface IServiceProvider.
    /// </summary>
    /// <remarks>
    ///     When inheriting from this interface, you should inherit from <see cref="IocContainer" />
    ///     so that the Register method is called on the initialization of the IocContainer.
    /// </remarks>
    public interface IServiceProvider
    {
        IServiceRequestHandler RequestHandler { get; }
        TInterface FetchInstance<TInterface>();
        void Register();
    }

    /// <summary>
    ///     Class ServiceProvider. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="IocContainer" />
    /// <seealso cref="IServiceProvider" />
    public sealed class ServiceProvider : IocContainer, IServiceProvider
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ServiceProvider" /> class.
        /// </summary>
        /// <param name="requestHandler">The request handler.</param>
        public ServiceProvider(IServiceRequestHandler requestHandler)
        {
            RequestHandler = requestHandler;
        }

        /// <summary>
        ///     Gets the request handler.
        /// </summary>
        /// <value>The request handler.</value>
        public IServiceRequestHandler RequestHandler { get; }

        /// <summary>
        ///     Registers service instances.
        /// </summary>
        public override void Register()
        {
            Register<IProjectService, ProjectService>(() => new ProjectService(RequestHandler));  
            Register<IProjectDetailService, ProjectDetailService>(() => new ProjectDetailService(RequestHandler));
            Register<ITimeService, TimeService>(() => new TimeService(RequestHandler));
        }
    }
}