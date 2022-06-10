namespace Intership_ProjectTeam4.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsDeleted { get; set; }=false;
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int  ProjectId { get; set; }
        public Project Project { get; set; }
        [ForeignKey("Tasks")]
        public int TasksId { get; set; }
        public Tasks Task { get; set; }
    }
}
    