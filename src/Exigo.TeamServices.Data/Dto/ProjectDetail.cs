using System;

using Exigo.TeamServices.Data.Repository.Base;

using NPoco;

namespace Exigo.TeamServices.Data.Dto
{
    public class ProjectDetail : IDto
    {
        public int CompanyId { get; set; }

        [Column("TicketId")]
        public int ProjectId { get; set; }

        [Column("TicketDetailId")]
        public int? Id { get; set; }

        public DateTime EntryDate { get; set; }
        public bool IsPublic { get; set; }
        public string Detail { get; set; }
        public int? EntryUserId { get; set; }

        [Ignore]
        public string CompanyName { get; set; }

        [Ignore]
        public User User { get; set; }

        [Ignore]
        public TimeEntry[] TimeEntries { get; set; }
    }
}