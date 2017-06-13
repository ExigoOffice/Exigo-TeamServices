using System.Collections.Generic;

namespace Exigo.TeamServices.Data.Repository.Base
{
    public interface ICrudRepository<in TParameter> : IRepository where TParameter : IDto
    {
        string Create(TParameter projectDetail);
        void CreateMany(IEnumerable<TParameter> entries);
        void Update(TParameter entry);
        void UpdateMany(IEnumerable<TParameter> entries);
        void Delete(TParameter entry);
    }

    public interface IDto { }
}