using ProjectEmployee_Intership.Database;
using System.ComponentModel.DataAnnotations;


namespace ProjectEmployee_Intership.Core.Entities
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
