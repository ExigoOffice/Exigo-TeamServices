using Exigo.TeamServices.Api.Base;
using Exigo.TeamServices.Api.Data;
using Exigo.TeamServices.Api.Handlers;
using Exigo.TeamServices.Data.Dto;

namespace Exigo.TeamServices.Api.Services
{
    /// <summary>
    ///     Class ProjectService.
    /// </summary>
    /// <seealso cref="Project" />
    /// <seealso cref="IProjectService" />
    public class ProjectService : CrudService<Project>, IProjectService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectService" /> class.
        /// </summary>
        /// <param name="requestHandler">The request handler.</param>
        public ProjectService(IServiceRequestHandler requestHandler) : base(requestHandler) {}

        /// <summary>
        ///     Gets the entity URL.
        /// </summary>
        /// <value>The entity URL.</value>
        public override string EntityUrl { get; } = "Projects";


        /// <summary>
        /// Gets new projects.
        /// </summary>
        /// <returns>ServiceApiResponse.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ServiceApiResponse GetNewProjects()
        {
            return SendGetRequest();
        }
    }

    public interface IProjectService : ICrudService<Project>, IRestApiService
    {
        ServiceApiResponse GetNewProjects();
    }
}