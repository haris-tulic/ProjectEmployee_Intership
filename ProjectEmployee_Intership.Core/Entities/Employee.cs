using System.ComponentModel.DataAnnotations;

namespace ProjectEmployee_Intership.Core.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Project> Projects { get; set; }
        public List<Tasks> Tasks { get; set; }
        public bool IsDeleted { get; set; }
    }
}
