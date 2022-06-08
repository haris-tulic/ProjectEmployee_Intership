namespace Intership_ProjectTeam4.Database
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
        public List<ProjectUser> Projects { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}
