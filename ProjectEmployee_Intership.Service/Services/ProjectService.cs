using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEmployee_intership.Database;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Database;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_Intership.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectUserContext _context;

        private readonly IMapper _mapper;
        public ProjectService(ProjectUserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDto> AddProject(AddProjectRequest newProject)
        {

            var project = _mapper.Map<Project>(newProject);

            if (!string.IsNullOrWhiteSpace(newProject.TaskId.ToString()) && newProject.TaskId.ToString() != "0")
            {
                var taskExist = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == newProject.TaskId && !t.IsDeleted && !t.IsFinished);
                if (taskExist == null)
                    throw new ArgumentException("Task doesn't exist!");

                project.Tasks = new List<Tasks>(); 
                project.Tasks.Add(taskExist);
            }


            if (!string.IsNullOrWhiteSpace(newProject.EmployeeId.ToString()) && newProject.EmployeeId.ToString() != "0")
            {
                var employeeExist = await _context.Employees.FirstOrDefaultAsync(e => e.Id == newProject.EmployeeId);
                if (employeeExist == null)
                    throw new ArgumentException("Employee doesn't exist!");
                project.Employee = new List<Employee>();
                project.Employee.Add(employeeExist);
                
            }


            if (!string.IsNullOrWhiteSpace(newProject.UserId.ToString()) && newProject.UserId.ToString() != "0")
            {
                var userExist = await _context.Users.Include(u=> u.Tasks).Include(u=>u.Role).FirstOrDefaultAsync(u => u.Id == newProject.UserId && !u.IsDeleted);
                if (userExist == null)
                    throw new ArgumentException("User doesn't exist!");
                project.Users = new List<User>();
                project.Users.Add(userExist); 
               
            }

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(project);
        }

        public void CheckStatusProject(int id)
        {
            var project =  _context.Projects.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
            if (project == null)
            {
                throw new ArgumentException("Project doesn't exist");
            }
            if (DateTime.Now > project.FinishDate)
            {
                project.Status = Common.Enums.StatusProject.InActive;
            }
            _context.SaveChanges();

        }

        public async Task<ProjectDto> DeleteProject(int id)
        {

            var project = await _context.Projects.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (project == null)
            {
                throw new ArgumentException("Project doesn't exist!");
            }
            project.IsDeleted = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(project);


        }

        public async Task<List<ProjectDto>> GetAllProjects(int? pageNumber, int? pageSize)
        {
                var listActiveProject = _context.Projects as IQueryable<Project>;
                listActiveProject = listActiveProject.
                    Include(p => p.Tasks).Include(p => p.Users).Include("Users.Role").Include(p => p.Employee)
                    .Where(x => !x.IsDeleted && x.Status == Common.Enums.StatusProject.Active);
               
                if (listActiveProject == null)
                    throw new ArgumentException("Projects doens't exist!");
                
                var pgNumber = pageNumber ?? 1;
                var pgSize = pageSize ?? 5;
                var list = await listActiveProject.Skip(pgSize * (pgNumber - 1)).Take(pgSize).ToListAsync();
                return _mapper.Map<List<ProjectDto>>(list);
        }

        public async Task<List<ProjectDto>> GetAllProjectsWithFillters(GetProjectRequest search)
        {
            try
            {
                var listProjects = _context.Projects.Include(p => p.Employee).Include(p => p.Tasks).Include(p => p.Users).AsQueryable();
                if (!string.IsNullOrWhiteSpace(search.ProjectName))
                {
                    search.ProjectName = search.ProjectName.Trim();
                    listProjects = listProjects.Where(x => x.ProjectName.Contains(search.ProjectName));
                }
                if (!string.IsNullOrWhiteSpace(search.FirstName))
                {
                    search.FirstName = search.FirstName.Trim();
                    var employee = _context.Employees.FirstOrDefault(x => x.FirstName.Contains(search.FirstName));
                    if (employee != null)
                    {
                        listProjects = listProjects.Where(x => x.Employee.Contains(employee));
                    }
                }
                var listActive = new List<Project>();
                var sorted = new List<Project>();
                listActive = listProjects.ToList();
                if (search.OrderBy != null)
                {
                    switch (search.OrderBy)
                    {
                        case "StartDate":
                            sorted = listActive.OrderBy(q => q.StartDate).ToList();
                            break;
                        case "FinishDate":
                            sorted = listActive.OrderBy(q => q.FinishDate).ToList();
                            break;
                        default:
                            sorted = listActive.OrderBy(q => q.StartDate).ToList();
                            break;
                    }
                    
                }
                return _mapper.Map<List<ProjectDto>>(sorted);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            

            
           
        }

        public async Task<ProjectDto> GetProjectById(int id)
        {
            var project = await _context.Projects.Include(p=> p.Tasks).Include(p=> p.Employee).Include(p=> p.Users).FirstOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                throw new ArgumentException("Project doesn't exist");
            }
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ServiceResponse<ProjectDto>> UpdateProject(AddProjectRequest request, int id)
        {
            var response = new ServiceResponse<ProjectDto>();
            var projectExist = await _context.Projects.
                Include(x => x.Tasks).
                Include(x => x.Users).
                Include(x => x.Employee).
                FirstOrDefaultAsync(x => x.Id == id);

            if (projectExist == null)
            {
                throw new ArgumentException("Project doesn't exist!");
            }

            _mapper.Map(request, projectExist);

            var taskExist = await TaskExist(request.TaskId, projectExist);
            if (!taskExist.Success)
            {
                response.Message += " " + taskExist.Message;
            }

            var employeeExist = await EmployeeExist(request.EmployeeId, projectExist);
            if (!employeeExist.Success)
            {
                response.Message += " " + employeeExist.Message;
            }

            var userExist = await UserExist(request.UserId, projectExist);
            if (!userExist.Success)
            {
                response.Message += " " + userExist.Message;
            }
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<ProjectDto>(projectExist);
            response.Success = true;
            return response;

        }

        private async Task<ServiceResponse<Tasks>> TaskExist(int? TaskId, Project project)
        {
            var response = new ServiceResponse<Tasks>();
            if (TaskId.HasValue)
            {
                var tasks = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == TaskId && !t.IsDeleted);
                if (tasks != null)
                {
                    project.Tasks.Add(tasks);
                    response.Success = true;
                    response.Data = tasks;
                    return response;
                }
                response.Success = false;
                response.Data = null;
                response.Message = "We didn't add task to project because task doesn't exist";
            }
            return response;
        }
        private async Task<ServiceResponse<Employee>> EmployeeExist(int? EmployeeId, Project project)
        {
            var response = new ServiceResponse<Employee>();
            if (EmployeeId.HasValue)
            {
                var employee = await _context.Employees.Include(x=> x.Tasks).Include(x=>x.Projects).FirstOrDefaultAsync(e => e.Id == EmployeeId && !e.IsDeleted);
                if (employee != null)
                {
                    project.Employee.Add(employee);
                    response.Success = true;
                    response.Data = employee;
                    return response;
                }
                response.Success = false;
                response.Data = null;
                response.Message = "We didn't add employee to project because employee doesn't exist";
            }
            return response;
        }
        private async Task<ServiceResponse<User>> UserExist(int? UserId, Project project)
        {
            var response = new ServiceResponse<User>();
            if (UserId.HasValue)
            {
                var user = await _context.Users.Include(x=> x.Role).FirstOrDefaultAsync(e => e.Id == UserId && !e.IsDeleted && e.Role.Name.Contains("User"));
                if (user != null)
                {
                    project.Users.Add(user);
                    response.Success = true;
                    response.Data = user;
                    return response;
                }
                response.Success = false;
                response.Data = null;
                response.Message = "We didn't add user to project because user doesn't exist";
            }
            return response;
        }
    }
}
