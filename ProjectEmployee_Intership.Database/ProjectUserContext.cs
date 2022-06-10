 using Microsoft.EntityFrameworkCore;
using ProjectEmployee_Intership.Core.Entities;

namespace ProjectEmployee_Intership.Entities
{
    public class ProjectUserContext : DbContext
    {
        public ProjectUserContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().
        //}
    }
}
