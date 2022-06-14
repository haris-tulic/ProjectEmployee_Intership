using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEmployee_intership.Database;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Helper;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
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
            try
            {
                var project = _mapper.Map<Project>(newProject);

                var taskExist = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == newProject.TaskId && !t.IsDeleted && !t.IsFinished);
                if (taskExist == null)
                {
                    throw new ArgumentException("Task doesn't exist!");
                }

                var employeeExist = await _context.Employees.FirstOrDefaultAsync(e => e.Id == newProject.EmployeeId);
                if (employeeExist == null)
                {
                    throw new ArgumentException("Employee doesn't exist!");
                }

                var userExist = await _context.Users.FirstOrDefaultAsync(u => u.Id == newProject.UserId && !u.IsDeleted);
                if (userExist == null)
                {
                    throw new ArgumentException("User doesn't exist!");
                }
                project.Employee.Add(employeeExist);
                project.Tasks.Add(taskExist);
                project.Users.Add(userExist);
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return _mapper.Map<ProjectDto>(project);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            

        }

        public async Task<ProjectDto> DeleteProject(int id)
        {
            try
            {
                var project=await _context.Projects.FirstOrDefaultAsync(x=>!x.IsDeleted && x.Id == id);
                if (project==null)
                {
                    throw new ArgumentException("Project doesn't exist!");
                }
                project.IsDeleted = true;
                await _context.SaveChangesAsync();
                return _mapper.Map<ProjectDto>(project);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<ProjectDto>> GetAllProjects(int ?pageNumber ,int ?pageSize)
        {
            try
            {
                var listActiveProject = _context.Projects as IQueryable<Project>;
                listActiveProject =  listActiveProject.
                    Include(p=>p.Tasks).Include(p=>p.Users).Include(p=>p.Employee)
                    .Where(x => !x.IsDeleted && x.Status == Common.Enums.StatusProject.Active);
                if (listActiveProject == null)
                {
                    throw new ArgumentException("Projects doens't exist!");
                }
                var pgNumber = pageNumber ?? 1;
                var pgSize = pageSize ?? 5;
                var list= await listActiveProject.Skip(pgSize * (pgNumber - 1)).Take(pgSize).ToListAsync();
                return _mapper.Map<List<ProjectDto>>(list);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<ProjectDto>> GetAllProjectsWithFillters(GetProjectRequest search)
        {
            try
            {
                var listProjects = _context.Projects.AsQueryable();
                if (!string.IsNullOrWhiteSpace(search.ProjectName))
                {
                   search.ProjectName = search.ProjectName.Trim();
                   listProjects= listProjects.Where(x => x.ProjectName==search.ProjectName);
                }
                if (!string.IsNullOrWhiteSpace(search.FirstName))
                {
                    search.FirstName = search.FirstName.Trim();
                    var employee =await _context.Employees.FirstOrDefaultAsync(x => x.FirstName.Contains(search.FirstName));
                    if (employee==null)
                    {
                        throw new ArgumentException("Employee doesn't exist!");
                    }
                    var list = await _context.Projects.Include(x => x.Employee).Where(x => x.Employee.Contains(employee)).ToListAsync();
                    return _mapper.Map<List<ProjectDto>>(list);
                }
                var listProjectsM = _mapper.Map<List<ProjectDto>>(listProjects);
                return listProjectsM;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ProjectDto> GetProjectById(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x=>x.Id==id);
            if (project==null)
            {
                throw new ArgumentException("Project doesn't exist");
            }
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> UpdateProject(AddProjectRequest request, int id)
        {
            try
            {
                var projectExist = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
                if (projectExist==null)
                {
                    throw new ArgumentException("Project doesn't exist!");
                }
                _mapper.Map(request, projectExist);
                await _context.SaveChangesAsync();
                return _mapper.Map<ProjectDto>(projectExist);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
           
        }
    }
}
