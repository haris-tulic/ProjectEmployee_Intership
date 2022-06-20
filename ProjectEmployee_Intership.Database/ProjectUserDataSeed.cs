using Microsoft.EntityFrameworkCore;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_intership.Database
{
    public static class ProjectUserContextSeeder
    {
        public static void Seed(ProjectUserContext context)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash("123456", out passwordHash, out passwordSalt);
            void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            }

            var role1 = new Role()
            {
                //Id = 1,
                IsDeleted = false,
                Name = "Admin",
                Users = new List<User>(),

            };
            var role2 = new Role()
            {
                //Id = 2,
                IsDeleted = false,
                Name = "User",
                Users = new List<User>(),
            };
            var user1 = new User()
            {
                //Id = 1,
                IsDeleted = false,
                Username = "haris",
                Role = role1,
                Tasks = new List<Tasks>(),
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                
            };
            var user2 = new User()
            {
                //Id = 2,
                IsDeleted = false,
                Username = "emina",
                Role = new Role(),
                Tasks = new List<Tasks>(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            var employee1 = new Employee()
            {
                //Id = 1,
                FirstName = "Adin",
                LastName = "Smajkic",
                IsDeleted = false,
                Projects = new List<Project>(),
                Tasks = new List<Tasks>()

            };
            var employee2 = new Employee()
            {
                //Id = 2,
                FirstName = "Smajo",
                LastName = "Durakovic",
                IsDeleted = false,
                Projects = new List<Project>(),
                Tasks = new List<Tasks>(),
            };
            var project1 = new Project()
            {
                //Id = 1,
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
                //Id = 2,
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
                //Id = 1,
                Name = "Task 1",
                Description = "Task for project: Project Manager",
                DeadLine = DateTime.Now.AddDays(3),
                IsDeleted = false,
                IsFinished = false,
                Employees = new List<Employee>(),
                Project = new Project(),
                Users = new List<User>()
            };
            var task2 = new Tasks()
            {
                //Id = 2,
                Name = "Task 1",
                Description = "Task for project: Movie Rating",
                DeadLine = DateTime.Now.AddDays(3),
                IsDeleted = false,
                IsFinished = false,
                Employees = new List<Employee>(),
                Project = new Project(),
                Users = new List<User>(),
            };
            project1.Tasks.Add(task1);
            project2.Tasks.Add(task2);
            project1.Employee.Add(employee1);
            project2.Employee.Add(employee2);
            role1.Users.Add(user1);
            role2.Users.Add(user2);
            user1.Tasks.Add(task1);
            user2.Tasks.Add(task2);
            user1.Project = project1;
            user2.Project = project2;
            employee1.Tasks.Add(task1);
            employee2.Tasks.Add(task2);

            context.Projects.AddRange(project1,project2);
            context.Roles.AddRange(role1, role2);
            context.Users.AddRange(user1,user2);
            context.Employees.AddRange(employee1,employee2);
            context.Tasks.AddRange(task1,task2);
            context.SaveChanges();
        }
       
    }
}
