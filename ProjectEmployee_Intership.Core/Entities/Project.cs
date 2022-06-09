
using System.ComponentModel.DataAnnotations;
using ProjectEmployee_Intership.Common.Enums;

namespace ProjectEmployee_Intership.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public StatusProject Status { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<ProjectEmployee> Employees { get; set; }
        public List<Tasks> Tasks { get; set; }
        
    }
}
