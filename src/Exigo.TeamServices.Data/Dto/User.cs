using System;

using Exigo.TeamServices.Data.Repository.Base;

using NPoco;

namespace Exigo.TeamServices.Data.Dto
{
    [TableName("Users")]
    public class User : IDto
    {
        [Column("UserId")]
        public int? Id { get; set; }

        [Column("DepartmentTy")]
        public int DepartmentId { get; set; }

        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public byte IsActive { get; set; }
        public byte UserTy { get; set; }
        public bool IsDeleted { get; set; }
        public bool AllowApiaccess { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Password { get; set; }

        [Ignore]
        public Department Department { get; set; }
    }
}