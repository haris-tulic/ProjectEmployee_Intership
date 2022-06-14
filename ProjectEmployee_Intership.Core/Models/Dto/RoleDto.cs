namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class RoleDto
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<UserDto> Users { get; set; }
    }
}