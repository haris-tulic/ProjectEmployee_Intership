using Microsoft.EntityFrameworkCore;
using ProjectEmployee_Intership.Core.Entities;

namespace ProjectEmployee_Intership.Entities
{
    public class ProjectEmployeeContext : DbContext
    {
        public ProjectEmployeeContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
