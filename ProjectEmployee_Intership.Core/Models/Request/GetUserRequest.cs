using ProjectEmployee_Intership.Core.Models.Dto;

namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class GetUserRequest
    {
        public RoleDto Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
