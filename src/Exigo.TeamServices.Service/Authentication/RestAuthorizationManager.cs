using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using Exigo.TeamServices.Data.Dto;
using Exigo.TeamServices.Data.IoC;
using Exigo.TeamServices.Data.Repository;

namespace Exigo.TeamServices.Service.Authentication
{
    public class RestAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            var authHeader = WebOperationContext.Current?.IncomingRequest.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader))
            {
                WebOperationContext.Current?.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"TeamServices\"");             
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            var svcCredentials = Encoding.ASCII.GetString(Convert.FromBase64String(authHeader.Substring(6))).Split(':');
            var user = new User
            {
                LoginName = svcCredentials[0],
                Password = svcCredentials[1]
            };

            return AuthenticateUser(user).Id.HasValue;
        }

        private User AuthenticateUser(User requestingUser)
        {
            var userRepository = RepositoryContainer.DefaultContainer.FethInstance<IUserRepository>();
            var user = userRepository.GetUser(u => u.LoginName == requestingUser.LoginName && u.Password == requestingUser.Password);
            return user;
        }
    }
}