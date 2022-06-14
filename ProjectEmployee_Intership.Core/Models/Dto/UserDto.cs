namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class UserDto
    {
        public RoleDto Role { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TasksDto> Tasks { get; set; }
    }
}