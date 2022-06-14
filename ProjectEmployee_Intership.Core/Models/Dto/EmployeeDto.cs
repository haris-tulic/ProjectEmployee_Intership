namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<TasksDto> Tasks { get; set; }
        public UserDto User { get; set; }
    }
}
