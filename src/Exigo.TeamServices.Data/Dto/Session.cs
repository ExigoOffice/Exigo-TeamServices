namespace Exigo.TeamServices.Data.Dto
{
    public class Session
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public AuthenticationToken Token { get; set; }
    }
}