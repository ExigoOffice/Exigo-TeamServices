using Exigo.TeamServices.Data.Repository.Base;

using NPoco;

namespace Exigo.TeamServices.Data.Dto
{
    [TableName("DepartmentTy")]
    public class Department : IDto
    {
        [Column("DepartmentTy")]
        public int? Id { get; set; }

        [Column("Descr")]
        public string Name { get; set; }

        [Ignore]
        public User[] Users { get; set; }
    }
}