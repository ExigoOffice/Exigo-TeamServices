using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using NPoco.fastJSON;

namespace Exigo.TeamServices.Data.Repository.Base
{
    public abstract class RepositoryBase<T> : ICrudRepository<T>, IQueryRepository<T> where T : IDto
    {
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        /// <inheritdoc />
        public IDbFactory DbFactory { get; }

        /// <inheritdoc />
        public virtual string Create(T entry)
        {
            using (var db = DbFactory.GetConnection()) return JSON.ToJSON(db.Insert(entry));
        }

        /// <inheritdoc />
        public void CreateMany(IEnumerable<T> entries)
        {
            using (var db = DbFactory.GetConnection()) db.InsertBulk(entries);
        }

        /// <inheritdoc />
        public virtual void Update(T entry)
        {
            using (var db = DbFactory.GetConnection()) db.Update(entry);
        }

        /// <inheritdoc />
        public void UpdateMany(IEnumerable<T> entries)
        {
            using (var db = DbFactory.GetConnection()) foreach (var entry in entries) db.Update(entry);
        }

        /// <inheritdoc />
        public virtual void Delete(T entry)
        {
            using (var db = DbFactory.GetConnection()) db.Delete(entry);
        }

        /// <inheritdoc />
        public T FetchById(int id)
        {
            using (var db = DbFactory.GetConnection()) return db.SingleOrDefaultById<T>(id);
        }

        /// <inheritdoc />
        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            using (var db = DbFactory.GetConnection()) return db.Query<T>().Where(expression).ToEnumerable();
        }
    }
}