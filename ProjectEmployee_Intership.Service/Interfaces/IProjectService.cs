using ProjectEmployee_Intership.Core.Helper;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllProjects(int ?pageNumber, int ?pageSize);
        Task<List<ProjectDto>> GetAllProjectsWithFillters(GetProjectRequest search);
        Task<ProjectDto> GetProjectById(int id);
        Task<ProjectDto> AddProject(AddProjectRequest newProject);
        Task<ProjectDto> DeleteProject(int id);
        Task<ProjectDto> UpdateProject(AddProjectRequest request, int id);
    }
}
