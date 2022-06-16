using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<TasksDto> Tasks { get; set; }
    }
}
