using Exigo.TeamServices.Data.Repository.Base;

using NPoco;

namespace Exigo.TeamServices.Data.Dto
{
    public class Session : IDto
    {
        [Column("SessionId")]
        public int? Id { get; set; }
        public int UserId { get; set; }
        public AuthenticationToken Token { get; set; }
    }
}