using System;
using System.Threading.Tasks;

using Exigo.TeamServices.Api.Base;
using Exigo.TeamServices.Api.Handlers;
using Exigo.TeamServices.Data.Dto;

namespace Exigo.TeamServices.Api
{
    public interface IProjectDetailService : ICrudService<ProjectDetail>, IRestApiService {}

    /// <summary>
    ///     Class ProjectService.
    /// </summary>
    /// <seealso cref="ProjectDetail" />
    /// <seealso cref="IProjectDetailService" />
    public class ProjectDetailService : CrudService<ProjectDetail>, IProjectDetailService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectDetailService" /> class.
        /// </summary>
        /// <param name="requestHandler">The request handler.</param>
        public ProjectDetailService(IServiceRequestHandler requestHandler) : base(requestHandler) {}

        /// <summary>
        ///     Gets the entity URL.
        /// </summary>
        /// <value>The entity URL.</value>
        public override string EntityUrl { get; } = "ProjectDetails";
    }
}