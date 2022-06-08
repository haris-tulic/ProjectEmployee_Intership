namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class UserDto
    {
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ProjectEmployeeDto> Projects { get; set; }
        public List<TasksDto> Tasks { get; set; }
    }
}