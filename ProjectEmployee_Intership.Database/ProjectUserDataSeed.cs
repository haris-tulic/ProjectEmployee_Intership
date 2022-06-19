using Microsoft.EntityFrameworkCore;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_intership.Database
{
    public partial class ProjectUserContext
    {
        partial void OnModelCreatingPartial(ModelBuilder builder, ProjectUserContext context)
        {
            var role1 = new Role()
            {
                Id = 1,
                IsDeleted = false,
                Name = "Admin",
                Users = new List<User>(),

            };
            var role2 = new Role()
            {
                Id = 2,
                IsDeleted = false,
                Name = "User",
                Users = new List<User>(),
            };
            var user1 = new User()
            {
                Id = 1,
                IsDeleted = false,
                Username = "haris",
                Role = new Role(),
                Project = new Project(),
                Tasks = new List<Tasks>(),
            };
            var user2 = new User()
            {
                Id = 2,
                IsDeleted = false,
                Username = "emina",
                Role = new Role(),
                Project = new Project(),
                Tasks = new List<Tasks>(),
            };
            var employee1 = new Employee()
            {
                Id = 1,
                FirstName = "Adin",
                LastName = "Smajkic",
                IsDeleted = false,
                Projects = new List<Project>(),
                Tasks = new List<Tasks>(),
            };
            var employee2 = new Employee()
            {
                Id = 2,
                FirstName = "Smajo",
                LastName = "Durakovic",
                IsDeleted = false,
                Projects = new List<Project>(),
                Tasks = new List<Tasks>(),
            };
            var project1 = new Project()
            {
                Id = 1,
                ProjectName = "Project Manager",
                Status = ProjectEmployee_Intership.Common.Enums.StatusProject.Active,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(3),
                IsDeleted = false,
                Employee = new List<Employee>(),
                Tasks = new List<Tasks>(),
                Users = new List<User>(),

            };
            var project2 = new Project()
            {
                Id = 2,
                ProjectName = "Movie Rating",
                Status = ProjectEmployee_Intership.Common.Enums.StatusProject.Active,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(3),
                IsDeleted = false,
                Employee = new List<Employee>(),
                Tasks = new List<Tasks>(),
                Users = new List<User>(),
            };
            var task1 = new Tasks()
            {
                Id = 1,
                Name = "Task 1",
                Description = "Task for project: Project Manager",
                DeadLine = DateTime.Now.AddDays(3),
                IsDeleted = false,
                IsFinished = false,
                Employees = new List<Employee>(),
                Project = new Project(),
                Users = new List<User>(),
            };
            var task2 = new Tasks()
            {
                Id = 2,
                Name = "Task 1",
                Description = "Task for project: Movie Rating",
                DeadLine = DateTime.Now.AddDays(3),
                IsDeleted = false,
                IsFinished = false,
                Employees = new List<Employee>(),
                Project = new Project(),
                Users = new List<User>(),
            };
            role1.Users.Add(user1);
            role2.Users.Add(user2);
            user1.Project = project1;
            user2.Project = project2;
            user1.Tasks.Add(task1);
            user2.Tasks.Add(task2);
            employee1.Projects.Add(project1);
            employee2.Projects.Add(project2);
            employee1.Tasks.Add(task1);
            employee2.Tasks.Add(task2);
            project1.Tasks.Add(task1);
            project2.Tasks.Add(task2);

            role1.Users.Add(user1);
            role2.Users.Add(user2);
            user1.Project = project1;
            user2.Project = project2;
            user1.Tasks.Add(task1);
            user2.Tasks.Add(task2);
            employee1.Projects.Add(project1);
            employee2.Projects.Add(project2);
            employee1.Tasks.Add(task1);
            employee2.Tasks.Add(task2);
            project1.Tasks.Add(task1);
            project2.Tasks.Add(task2);

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Roles.Add(role1);
            context.Roles.Add(role2);
            context.Employees.Add(employee1);
            context.Employees.Add(employee2);
            context.Projects.Add(project1);
            context.Projects.Add(project2);
            context.Tasks.Add(task1);
            context.Tasks.Add(task2);

            context.SaveChanges();



            //byte[] passwordHash;
            //byte[] passwordSalt;
            //CreatePasswordHash("123456", out passwordHash, out passwordSalt);
            //void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            //{
            //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
            //    {
            //        passwordSalt = hmac.Key;
            //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            //    }
            //}
            //modelBuilder.Entity<Role>().HasData(new Role()
            //{
            //    Id = 1,
            //    IsDeleted = false,
            //    Name = "Admin",
            //    Users = new List<User>(),

            //});
            //modelBuilder.Entity<Role>().HasData(new Role()
            //{
            //    Id = 2,
            //    IsDeleted = false,
            //    Name = "User",
            //    Users = new List<User>(),
            //}) ;


            //modelBuilder.Entity<User>().HasData(new User()
            //{
            //    Id = 1,
            //    IsDeleted = false,
            //    Username = "haris",
            //    Role = new Role { Id = 1 },
            //    Project = new Project { Id = 1 },
            //    Tasks = new List<Tasks>(),
            //    //PasswordHash = passwordHash,
            //    //PasswordSalt = passwordSalt, 


            //});
            //modelBuilder.Entity<User>().HasData(new User()
            //{
            //    Id = 2,
            //    IsDeleted = false,
            //    Username = "emina",
            //    Role = new Role { Id = 2 },
            //    Project = new Project { Id = 2 },
            //    Tasks = new List<Tasks> (),
            //    //PasswordHash = passwordHash,
            //    //PasswordSalt = passwordSalt,


            //});

            //modelBuilder.Entity<Employee>().HasData(new Employee()
            //{
            //    Id = 1,
            //    FirstName = "Adin",
            //    LastName = "Smajkic",
            //    IsDeleted = false,
            //    Projects = new List<Project>() { new Project()
            //    {

            //        Id = 1,
            //    ProjectName = "Project Manager",
            //    Status = ProjectEmployee_Intership.Common.Enums.StatusProject.Active,
            //    StartDate = DateTime.Now,
            //    FinishDate = DateTime.Now.AddDays(3),
            //    IsDeleted = false,
            //    Employee = new List<Employee>(),
            //    Tasks = new List<Tasks> (),
            //    Users = new List<User> (),

            //    } },
            //    Tasks = new List<Tasks> (),
            //});
            //modelBuilder.Entity<Employee>().HasData(new Employee ()
            //{
            //    Id = 2,
            //    FirstName = "Smajo",
            //    LastName = "Durakovic",
            //    IsDeleted = false,
            //    Projects = new List<Project>(),
            //    Tasks = new List<Tasks> (),
            //});


            //modelBuilder.Entity<Project>().HasData(new Project ()
            //{
            //    Id = 1,
            //    ProjectName = "Project Manager",
            //    Status = ProjectEmployee_Intership.Common.Enums.StatusProject.Active,
            //    StartDate = DateTime.Now,
            //    FinishDate = DateTime.Now.AddDays(3),
            //    IsDeleted = false,
            //    Employee = new List<Employee>(),
            //    Tasks = new List<Tasks> (),
            //    Users = new List<User> (),

            //});
            //modelBuilder.Entity<Project>().HasData(new Project ()
            //{
            //    Id = 2,
            //    ProjectName = "Movie Rating",
            //    Status = ProjectEmployee_Intership.Common.Enums.StatusProject.Active,
            //    StartDate = DateTime.Now,
            //    FinishDate = DateTime.Now.AddDays(3),
            //    IsDeleted = false,
            //    Employee = new List<Employee>(),
            //    Tasks = new List<Tasks> (),
            //    Users = new List<User> (),
            //});


            //modelBuilder.Entity<Tasks>().HasData(new Tasks()
            //{
            //    Id = 1,
            //    Name = "Task 1",
            //    Description = "Task for project: Project Manager",
            //    DeadLine = DateTime.Now.AddDays(3),
            //    IsDeleted = false,
            //    IsFinished = false,
            //    Employees = new List<Employee>() ,
            //    Project = new Project() { Id = 1 },
            //    Users = new List<User> (),

            //});
            //modelBuilder.Entity<Tasks>().HasData(new Tasks()
            //{
            //    Id = 2,
            //    Name = "Task 1",
            //    Description = "Task for project: Movie Rating",
            //    DeadLine = DateTime.Now.AddDays(3),
            //    IsDeleted = false,
            //    IsFinished = false,
            //    Employees = new List<Employee>(),
            //    Project = new Project { Id = 2 },
            //    Users = new List<User> (),

            //});


        }
    }
}
