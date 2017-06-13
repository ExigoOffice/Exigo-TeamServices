namespace Exigo.TeamServices.Data.Repository.Base
{
    public interface IRepository
    {
        IDbFactory DbFactory { get; }
    }
}