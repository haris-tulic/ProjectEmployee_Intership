using Microsoft.EntityFrameworkCore;

namespace Intership_ProjectTeam4.Database
{
    public class ProjectUserContext : DbContext
    {
        public ProjectUserContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectEmployees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
