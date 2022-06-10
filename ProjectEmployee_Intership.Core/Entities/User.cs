using ProjectEmployee_Intership.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEmployee_Intership.Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsDeleted { get; set; }=false;
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int  ProjectId { get; set; }
        public Project Project { get; set; }
        [ForeignKey("Tasks")]
        public List<Tasks> Tasks { get; set; }
    }
}
    