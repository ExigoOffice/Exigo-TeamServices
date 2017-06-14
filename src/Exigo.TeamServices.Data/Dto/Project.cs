using System;
using System.Collections.Generic;

using Exigo.TeamServices.Data.Core;
using Exigo.TeamServices.Data.Repository.Base;

using NPoco;

namespace Exigo.TeamServices.Data.Dto
{
    [TableName("Ticket")]
    public class Project : IDto
    {
        public int CompanyId { get; set; }

        [Column("TicketId")]
        public int? Id { get; set; }

        [Column("ReferenceTicketId")]
        public int? ReferenceProjectId { get; set; }

        [Column("TicketStatusTy")]
        public ProjectStatusTy ProjectStatusTy { get; set; }

        [Column("TicketTy")]
        public int ProjectTy { get; set; }

        [Column("TicketPriorityTy")]
        public int ProjectPriorityTy { get; set; }

        public int CustomerId { get; set; }
        public int? AccountManagerId { get; set; }
        public string Subject { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ProjectedDate { get; set; }
        public decimal ProjectedHours { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public DateTime ActivityDate { get; set; }
        public int WorkPriority { get; set; }
        public decimal WorkHoursTotal { get; set; }
        public string WarningMessage { get; set; }
        public bool IsWarningActive { get; set; }
        public bool IsHot { get; set; }
        public int Risk { get; set; }

        [Ignore]
        public IEnumerable<ProjectDetail> Details { get; set; }

        [Ignore]
        public User Owner { get; set; }

        [Ignore]
        public User AccountManager { get; set; }

        [Ignore]
        public string CustomerName { get; set; }

        [Ignore]
        public Project ReferenceProject { get; set; }
    }
}