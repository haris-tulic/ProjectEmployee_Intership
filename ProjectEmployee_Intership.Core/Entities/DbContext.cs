using ProjectEmployee_Intership.Models;
using Microsoft.EntityFrameworkCore;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_Intership.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
            public DbSet<User> Users { get; set; }
            public DbSet<Project> Projects { get; set; }
            public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
            public DbSet<Task> Tasks { get; set; }
        
          






    }
}
