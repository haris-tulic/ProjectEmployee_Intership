using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Models;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllProjects(int? pageNumber, int? pageSize);
        Task<List<ProjectDto>> GetAllProjectsWithFillters(GetProjectRequest search);
        Task<ProjectDto> GetProjectById(int id);
        Task<ProjectDto> AddProject(AddProjectRequest newProject);
        Task<ProjectDto> DeleteProject(int id);
        Task<ServiceResponse<ProjectDto>> UpdateProject(AddProjectRequest request, int id);
        void  CheckStatusProject(int id);
    }
}
