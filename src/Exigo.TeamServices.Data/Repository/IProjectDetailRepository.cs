using Exigo.TeamServices.Data.Dto;
using Exigo.TeamServices.Data.Repository.Base;

namespace Exigo.TeamServices.Data.Repository
{
    public class ProjectDetailRepository : RepositoryBase<ProjectDetail>, IProjectDetailRepository
    {
        /// <inheritdoc />
        public ProjectDetailRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IProjectDetailRepository : ICrudRepository<ProjectDetail>, IQueryRepository<ProjectDetail> { }
}