using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Exigo.TeamServices.Api.Data;
using Exigo.TeamServices.Api.Handlers;
using Exigo.TeamServices.Data.Repository.Base;

namespace Exigo.TeamServices.Api.Base
{
    public interface IRestApiService : IRestServiceUrl
    {
        ServiceApiResponse SendPostRequest<T>(T payload) where T : IDto;
        ServiceApiResponse GetEntityById<T>(int id) where T : IDto;
        Task<IEnumerable<T>> SendGetRequest<T>(string parameters);
        ServiceApiResponse SendGetRequest();
    }

    public abstract class RestApiService : IRestApiService
    {
        /// <summary>
        ///     Gets the request handler.
        /// </summary>
        /// <value>The request handler.</value>
        protected IServiceRequestHandler RequestHandler { get; }

        protected RestApiService(IServiceRequestHandler requestHandler)
        {
            RequestHandler = requestHandler;
        }

        /// <summary>
        ///     Gets the entity URL.
        /// </summary>
        /// <value>The entity URL.</value>
        public abstract string EntityUrl { get; }
        
        /// <summary>
        ///     Sends a post request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="payload">The payload.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual ServiceApiResponse SendPostRequest<T>(T payload) where T : IDto
            => RequestHandler.ExecutePost(payload, ToString());

        /// <summary>
        ///     Sends a get request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual ServiceApiResponse GetEntityById<T>(int id) where T : IDto
            => RequestHandler.ExecuteGet($@"{ToString()}/{id}");
        
        /// <summary>
        ///     Sends the get request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public async Task<IEnumerable<T>> SendGetRequest<T>(string parameters)
            => await RequestHandler.ExecuteFilteredGet<T>(parameters);

        /// <inheritdoc />
        public ServiceApiResponse SendGetRequest()
        {
            return RequestHandler.ExecuteGet(ToString());
        }

        /// <summary>
        ///     Sends the get request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public async Task<IEnumerable<T>> SendGetRequest<T>(Predicate<T> filterPredicate)
            => await RequestHandler.ExecuteFilteredGet(filterPredicate);

        /// <summary>
        ///     Returns the url of the service in .
        /// </summary>
        public override string ToString() => $@"{EntityUrl}";
    }
}