using System.ComponentModel.DataAnnotations;
using ProjectEmployee_Intership.Common.Enums;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_Intership.Core.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public StatusProject Status { get; set; } = StatusProject.Active;
        public bool IsDeleted { get; set; } = false;
        public List<Employee> Employee { get; set; }
        public List<Tasks> Tasks { get; set; }
        public List<User> Users { get; set; }

    }
}
