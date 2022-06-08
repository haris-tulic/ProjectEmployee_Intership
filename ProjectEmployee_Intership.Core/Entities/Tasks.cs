using System.ComponentModel.DataAnnotations;

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
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsFinished { get; set; } = false;
        public DateTime DeadLine { get; set; }
    }
}