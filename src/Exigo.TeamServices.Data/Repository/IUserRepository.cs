using Exigo.TeamServices.Data.Dto;
using Exigo.TeamServices.Data.Repository.Base;

namespace Exigo.TeamServices.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        /// <inheritdoc />
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IUserRepository : ICrudRepository<User>, IQueryRepository<User> { }
}