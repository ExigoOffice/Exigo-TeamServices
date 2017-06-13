using System.Collections.Generic;

using Exigo.TeamServices.Data.Dto;
using Exigo.TeamServices.Data.Repository.Base;

namespace Exigo.TeamServices.Data.Repository
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        /// <inheritdoc />
        public DepartmentRepository(IDbFactory dbFactory) : base(dbFactory) { }

        /// <inheritdoc />
        public IEnumerable<User> GetUsers(int departmentId)
        {
            using (var db = DbFactory.GetConnection())
            {
                return db.Query<User>()
                    .Where(u => u.DepartmentId == departmentId)
                    .OrderByDescending(u => u.FirstName)
                    .ToList();
            }
        }
    }

    public interface IDepartmentRepository : ICrudRepository<Department>, IQueryRepository<Department>
    {
        IEnumerable<User> GetUsers(int departmentId);
    }
}