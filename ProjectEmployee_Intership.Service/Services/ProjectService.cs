using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Entities;
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

        public Task<ProjectDto> AddProject(AddProjectRequest newProject)
        {
            throw new NotImplementedException();
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

        public async Task<List<ProjectDto>> GetAllProjects()
        {
            try
            {
                var listActiveProject = await _context.Projects.Where(x => !x.IsDeleted && x.Status == Common.Enums.StatusProject.Active).ToListAsync();
                if (listActiveProject==null)
                {
                    throw new ArgumentException("Projects doens't exist!");
                }
                return _mapper.Map<List<ProjectDto>>(listActiveProject);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public Task<List<ProjectDto>> GetAllProjectsWithFillters(GetProjectRequest search)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> UpdateProject(AddProjectRequest request, int id)
        {
            throw new NotImplementedException();
        }
    }
}
