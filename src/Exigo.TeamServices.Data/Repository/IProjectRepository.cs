using System.Collections.Generic;

using Exigo.TeamServices.Data.Core.Extensions;
using Exigo.TeamServices.Data.Dto;
using Exigo.TeamServices.Data.Repository.Base;

namespace Exigo.TeamServices.Data.Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        /// <inheritdoc />
        public ProjectRepository(IDbFactory dbFactory) : base(dbFactory) { }

        /// <inheritdoc />
        public IEnumerable<ProjectDetail> FetchTicketDetails(int projectDetailId)
        {
            using (var db = DbFactory.GetConnection())
            {
                return db.Query<ProjectDetail>()
                    .Where(pd => pd.ProjectId == projectDetailId)
                    .OrderByDescending(pd => pd.EntryDate)
                    .ToList();
            }
        }

        /// <inheritdoc />
        public void UpdateProjectWithDetails(Project project)
        {
            using (var db = DbFactory.GetConnection())
            {
                db.Update(project);
                var splitWhere = project.Details.SplitWhere(pd => pd.ProjectDetailId.HasValue);
                db.Update(splitWhere.SuccessList);
                db.InsertBulk(splitWhere.FailureList);
            }
        }
    }

    public interface IProjectRepository : ICrudRepository<Project>, IQueryRepository<Project>
    {
        IEnumerable<ProjectDetail> FetchTicketDetails(int projectDetailId);
        void UpdateProjectWithDetails(Project project);
    }
}