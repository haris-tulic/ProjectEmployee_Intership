using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_Intership.Core.Entities
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<User> Users { get; set; }
        public bool IsFinished { get; set; } = false;
        public DateTime DeadLine { get; set; }
        public List<Employee> Employees { get; set; }
    }
}