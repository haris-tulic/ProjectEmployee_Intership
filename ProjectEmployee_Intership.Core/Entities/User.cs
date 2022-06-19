using ProjectEmployee_Intership.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectEmployee_Intership.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Project? Project { get; set; }
        public List<Tasks> Tasks { get; set; }
        public string Username { get; set; }
    }
}
