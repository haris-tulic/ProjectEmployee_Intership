using ProjectEmployee_Intership.Core.Entities;

namespace ProjectEmployee_Intership.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ProjectEmployee> Projects { get; set; }
        public List<Tasks> Tasks { get; set; }
        public string Username { get; set; }
    }
}
