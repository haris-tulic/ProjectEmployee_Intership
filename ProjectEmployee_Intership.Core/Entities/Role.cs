using System.ComponentModel.DataAnnotations;

namespace Intership_ProjectTeam4.Database
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<User> Users { get; set; }
    }
}
