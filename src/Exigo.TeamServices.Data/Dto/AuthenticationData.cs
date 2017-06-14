using System;

using Exigo.TeamServices.Data.Authentication;

namespace Exigo.TeamServices.Data.Dto
{
    [Serializable]
    public class AuthenticationData
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? AuthenticationDateRequest { get; set; }

        public static implicit operator Session(AuthenticationData data)
        {
            var now = DateTime.UtcNow;
            var expire = now.Add(new TimeSpan(8, 0, 0));
            return new Session
            {
                UserId = data.UserId,
                Token = new AuthenticationToken
                {
                    CreatedDate = now,
                    ExpireDate = expire,
                    Value = Encryption.CreateTokenAuthenticationHash(now, expire, data)
                }
            };
        }
    }
}