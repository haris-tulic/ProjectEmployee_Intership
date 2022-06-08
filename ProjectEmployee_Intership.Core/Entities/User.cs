using ProjectEmployee_Intership.Core.Entities;

namespace ProjectEmployee_Intership.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsDeleted { get; set; }=false;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
    