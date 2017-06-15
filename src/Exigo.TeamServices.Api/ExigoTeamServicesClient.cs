using System;
using System.Collections.Generic;

using Exigo.TeamServices.Api.Handlers;
using Exigo.TeamServices.Api.Services;
using Exigo.TeamServices.Data.Dto;

using Newtonsoft.Json;

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


    public class Test
    {
        public static void TestMethod()
        {
            var client = new ExigoTeamServicesClient("username","password");

            // Get new projects
            var projectService = client.FetchInstance<IProjectService>();
            var result = projectService.GetNewProjects();
            var projects = JsonConvert.DeserializeObject<IEnumerable<Project>>(result.JsonResponseObject);
        }
    }
}