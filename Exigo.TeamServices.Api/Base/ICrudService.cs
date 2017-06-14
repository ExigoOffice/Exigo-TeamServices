using System.Threading.Tasks;

using Exigo.TeamServices.Api.Data;
using Exigo.TeamServices.Api.Exceptions;
using Exigo.TeamServices.Api.Handlers;
using Exigo.TeamServices.Data.Repository.Base;

namespace Exigo.TeamServices.Api.Base
{
    public interface ICrudService<in T> where T : IDto
    {
        ServiceApiResponse Create(T model);
        ServiceApiResponse Update(T model);
    }

    /// <summary>
    ///     Class CrudService.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="RestApiService " />
    /// <seealso cref="ICrudService{T}" />
    public abstract class CrudService<T> : RestApiService, ICrudService<T> where T : IDto
    {
        public abstract override string EntityUrl { get; }

        protected CrudService(IServiceRequestHandler requestHandler) : base(requestHandler) {}

        /// <summary>
        ///     Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="ExigoTeamServiceCreateEntityException">Unable to create an entity with the Id property set</exception>
        public virtual ServiceApiResponse Create(T model)
        {
            if (model.Id.HasValue)
                throw new ExigoTeamServiceCreateEntityException(
                    "Unable to create an entity with the Id property set");

            var response = SendPostRequest(model);
            return response;
        }

        /// <summary>
        ///     Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="ExigoTeamServiceCreateEntityException">Unable to update an entity with out the Id property set</exception>
        public virtual ServiceApiResponse Update(T model)
        {
            if (!model.Id.HasValue)
                throw new ExigoTeamServiceCreateEntityException(
                    "Unable to update an entity with out the Id property set");

            var response = SendPostRequest(model);
            return response;
        }
    }
}