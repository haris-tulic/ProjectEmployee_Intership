using Microsoft.EntityFrameworkCore;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;


namespace ProjectEmployee_intership.Database
{
    public partial class ProjectUserContext : DbContext
    {
        public ProjectUserContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer("Server=JAP-J3SVXT2\\MSSQLSERVER_OLAP; Database=ProjectManagerTest;Trusted_Connection=true;");

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JAP-J3SVXT2\\MSSQLSERVER_OLAP; Database=ProjectManagerTest;Trusted_Connection=true;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }


    }
}

