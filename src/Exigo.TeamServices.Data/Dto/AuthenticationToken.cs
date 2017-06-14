using System;

namespace Exigo.TeamServices.Data.Dto
{
    public struct AuthenticationToken
    {
        public int SessionId { get; set; }
        public byte[] Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}