using System.ComponentModel.DataAnnotations;

namespace Intership_ProjectTeam4.Database
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
        public int EmployeeId { get; set; }
        public User Employee { get; set; }
        public bool IsFinished { get; set; } = false;
        public DateTime DeadLine { get; set; }
    }
}