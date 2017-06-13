using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Exigo.TeamServices.Data.Repository.Base
{
    public interface IQueryRepository<T> where T : IDto
    {
        T FetchById(int id);

        /// <summary>
        ///     Returns <see cref="T" />s where the specified expression is true.
        /// </summary>
        /// <param name="expression">The expression to be executed.</param>
        /// <returns>IEnumerable&lt;Project&gt;.</returns>
        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
    }
}