using System;
using System.Linq.Expressions;

using Exigo.TeamServices.Data.Dto;
using Exigo.TeamServices.Data.Repository.Base;

namespace Exigo.TeamServices.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        /// <inheritdoc />
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }

        /// <inheritdoc />
        public User GetUser(Expression<Func<User, bool>> expression)
        {
            using (var db = DbFactory.GetConnection())
            {
                var user = db.Query<User>().FirstOrDefault(expression);
                return user;
            }
        }



        public void DOsometihg(Session data)
        {
            //
        }
    }

    public interface IUserRepository : ICrudRepository<User>, IQueryRepository<User> {
        User GetUser(Expression<Func<User, bool>> expression);
    }
}