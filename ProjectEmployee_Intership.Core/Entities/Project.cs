using Intership_ProjectTeam4.Enum;
using ProjectEmployee_Intership.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Intership_ProjectTeam4.Database
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
