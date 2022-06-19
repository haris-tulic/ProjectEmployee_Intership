using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Project> Projects { get; set; }
        public List<Tasks> Tasks { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
