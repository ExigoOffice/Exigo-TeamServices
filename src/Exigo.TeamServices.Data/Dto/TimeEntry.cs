using Exigo.TeamServices.Data.Repository.Base;

using NPoco;

namespace Exigo.TeamServices.Data.Dto
{
    public class TimeEntry : IDto
    {
        public int CompanyId { get; set; }

        [Column("TimeEntryId")]
        public int? Id { get; set; }

        [Column("TicketDetailId")]
        public int ProjectDetailId { get; set; }

        public string EntryComment { get; set; }
        public bool IsBillable { get; set; }
        public double WorkedTime { get; set; }
        public User UserId { get; set; }
    }
}