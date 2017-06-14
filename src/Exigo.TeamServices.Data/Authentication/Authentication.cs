using System.Security;

namespace Exigo.TeamServices.Data.Authentication
{
    public class Authentication
    {
        public string Username { get; set; }
        public SecureString Password { get; set; }
    }
}