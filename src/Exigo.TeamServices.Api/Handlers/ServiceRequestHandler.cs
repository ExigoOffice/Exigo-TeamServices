using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Exigo.TeamServices.Api.Data;
using Exigo.TeamServices.Data.Repository.Base;

using Newtonsoft.Json;

namespace Exigo.TeamServices.Api.Handlers
{
    /// <summary>
    ///     Class ServiceRequestHandler.
    /// </summary>
    /// <seealso cref="IServiceRequestHandler" />
    public class ServiceRequestHandler : IServiceRequestHandler
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ServiceRequestHandler" /> class.
        /// </summary>
        /// <param name="exigoTeamServicesBaseUri">The target process base URI.</param>
        /// <param name="username"></param>
        /// <param name="password">The password.</param>
        public ServiceRequestHandler(Uri exigoTeamServicesBaseUri, string username, string password)
        {
            ExigoTeamServicesBaseUri = exigoTeamServicesBaseUri;
            Password = password;
            Username = username;
        }

        /// <summary>
        ///     Gets the target process base URI.
        /// </summary>
        /// <value>The target process base URI.</value>
        public Uri ExigoTeamServicesBaseUri { get; }

        /// <summary>
        ///     Gets the associated password for api usage.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; }

        /// <summary>
        ///     Gets the associated username for api usage.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; }

        /// <summary>
        ///     execute post operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="payload">The payload.</param>
        /// <param name="url">The URL.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public ServiceApiResponse ExecutePost<T>(T payload, string url) where T : IDto
        {
            return SendRequest(CreateRequest(RequestMethod.POST, url, payload));
        }

        /// <summary>
        ///     execute get operation.
        /// </summary>
        /// <param name="urlWithParams">The URL with parameters.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public ServiceApiResponse ExecuteGet(string urlWithParams)
        {
            return SendRequest(CreateRequest(RequestMethod.GET, urlWithParams));
        }

        /// <summary>
        ///     This method is not currently implemented. Scheduled for release two
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IEnumerable<T>> ExecuteFilteredGet<T>(string parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     This method is not currently implemented. Scheduled for release two
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterPredicate">The filter predicate.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IEnumerable<T>> ExecuteFilteredGet<T>(Predicate<T> filterPredicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates a get request.
        /// </summary>
        /// <param name="requestMethod">The method.</param>
        /// <param name="url">The URL.</param>
        /// <returns>IRestRequest.</returns>
        private WebRequest CreateRequest(RequestMethod requestMethod, string url)
        {
            var webReq = WebRequest.CreateHttp(url);
            webReq.Method = Enum.GetName(typeof(RequestMethod), requestMethod);
            webReq.ContentType = "application/json; charset=utf-8";
            return webReq;
        }

        /// <summary>
        ///     Creates a request with a body.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestMethod">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="payload">The payload.</param>
        /// <returns>IRestRequest.</returns>
        private WebRequest CreateRequest<T>(RequestMethod requestMethod, string url, T payload) where T : IDto
        {
            var buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload));
            var webReq = WebRequest.CreateHttp(url);

            webReq.Method = Enum.GetName(typeof(RequestMethod), requestMethod);
            webReq.ContentType = "application/json; charset=utf-8";
            webReq.ContentLength = buffer.Length;
            return webReq;
        }

        private ServiceApiResponse SendRequest(WebRequest request)
        {
            using (var stream = request.GetRequestStream())
            {
                if (stream == null) throw new NullReferenceException();

                using (var reader = new StreamReader(stream))
                    return JsonConvert.DeserializeObject<ServiceApiResponse>(reader.ReadToEnd());
            }
        }
    }

    public interface IServiceRequestHandler
    {
        Uri ExigoTeamServicesBaseUri { get; }
        string Password { get; }
        string Username { get; }

        Task<IEnumerable<T>> ExecuteFilteredGet<T>(string parameters);
        Task<IEnumerable<T>> ExecuteFilteredGet<T>(Predicate<T> filterPredicate);
        ServiceApiResponse ExecuteGet(string urlWithParams);
        ServiceApiResponse ExecutePost<T>(T payload, string url) where T : IDto;
    }

}