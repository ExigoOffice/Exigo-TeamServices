using System;

using Exigo.TeamServices.Api.Handlers;

namespace Exigo.TeamServices.Api
{
    using Services.Providers;

    public class ExigoTeamServicesClient
    {
        private readonly IServiceProvider _provider;

        public ExigoTeamServicesClient(string username , string password)
        {
            _provider = new ServiceProvider(new ServiceRequestHandler(new Uri("TBD"), username, password));
        }

        public TInterface FetchInstance<TInterface>()
        {
            return _provider.FetchInstance<TInterface>();
        }
    }
}