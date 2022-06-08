using Microsoft.EntityFrameworkCore;

namespace Intership_ProjectTeam4.Database
{
    public class ProjectEmployeeContext : DbContext
    {
        public ProjectEmployeeContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
