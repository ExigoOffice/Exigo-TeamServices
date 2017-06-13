using System.Linq;

using Exigo.TeamServices.Data.Dto;
using Exigo.TeamServices.Data.Repository.Base;

namespace Exigo.TeamServices.Data.Repository
{
    public class TimeEntryRepository : RepositoryBase<TimeEntry>, ITimeEntryRepository
    {
        /// <inheritdoc />
        public TimeEntryRepository(IDbFactory dbFactory) : base(dbFactory) { }

        /// <inheritdoc />
        public double CalculateBilledTime(int projectDetailId)
        {
            using (var db = DbFactory.GetConnection())
            {
                return db.Query<TimeEntry>()
                    .Where(te => te.ProjectDetailId == projectDetailId)
                    .ToList().Sum(te => te.WorkedTime);
            }
        }
    }

    public interface ITimeEntryRepository : ICrudRepository<TimeEntry>, IQueryRepository<TimeEntry>
    {
        double CalculateBilledTime(int projectDetailId);
    }
}