using Microsoft.EntityFrameworkCore;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;


namespace ProjectEmployee_intership.Database
{
    public partial class ProjectUserContext : DbContext
    {
        public ProjectUserContext()
        {
        }
        public ProjectUserContext(DbContextOptions options) : base(options)
        {

        }

        ////protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer("Server=JAP-J3SVXT2\\MSSQLSERVER_OLAP; Database=ProjectManager;Trusted_Connection=true;");

        //}

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //ProjectUserContext context = new ProjectUserContext();
            base.OnModelCreating(builder);
            //OnModelCreatingPartial(builder,context);
        }
        partial void OnModelCreatingPartial(ModelBuilder builder,ProjectUserContext context);
    }
}

