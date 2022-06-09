using System.ComponentModel.DataAnnotations;

namespace ProjectEmployee_Intership.Entities
{
    public class ProjectEmployee
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}
