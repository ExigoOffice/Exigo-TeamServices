using NPoco;

namespace Exigo.TeamServices.Data.Repository.Base
{
    public class DbFactory : IDbFactory
    {
        private readonly string _connectionString;

        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDatabase GetConnection()
        {
            return new Database(_connectionString);
        }
    }

    public interface IDbFactory
    {
        IDatabase GetConnection();
    }
}