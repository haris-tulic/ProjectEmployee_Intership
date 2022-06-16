using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEmployee_Intership.Common.Enums;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_IntershipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly IRecurringJobManager _recurringJobManager;
        public ProjectController(IProjectService service, IRecurringJobManager recurringJobManager)
        {
            _service = service;
            _recurringJobManager = recurringJobManager;
        }

        // [Authorize(Roles = "User")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<ProjectDto>>> GetAllActiveProjects(int? pageNumber, int? pageSize)
        {
            var response = await _service.GetAllProjects(pageNumber, pageSize);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        
        //[Authorize(Roles = "User")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjectsWithFillters([FromQuery] GetProjectRequest search)
        {
            var response = await _service.GetAllProjectsWithFillters(search);
            if (response == null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //[Authorize(Roles = "User")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            var response = await _service.GetProjectById(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<ProjectDto>> AddNewProject(AddProjectRequest newProject)
        {
            var response = await _service.AddProject(newProject);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

       // [Authorize(Roles = "Admin")]
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<ProjectDto>>> UpdateProject(AddProjectRequest updateProject, int id)
        {
            var response = await _service.UpdateProject(updateProject, id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

       // [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<ProjectDto>> DeleteProject(int id)
        {
            var response = await _service.DeleteProject(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        
       /* [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> ChangeStatusById(int id)
        {
            var response = await _service.CheckStatus(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }*/

       











        /*private string CreateProdjectsUri(GetProjectRequest paramaters,UriType type)
        {
            switch (type)
            {
                case UriType.PreviousPage:
                    return Url.Link("GetAllActiveProjects", new
                    {
                        pageNumber = paramaters.PageNumber - 1,
                        pageSize = paramaters.PageSize,
                        ProjectName = paramaters.ProjectName,
                        StartDate = paramaters.StartDate,
                        FinishDate = paramaters.FinishDate,
                        Status = paramaters.Status,
                        FirstName = paramaters.FirstName,

                    });
                case UriType.NextPage:
                    return Url.Link("GetAllActiveProjects", new
                    {
                        pageNumber = paramaters.PageNumber + 1,
                        pageSize = paramaters.PageSize,
                        ProjectName = paramaters.ProjectName,
                        StartDate = paramaters.StartDate,
                        FinishDate = paramaters.FinishDate,
                        Status = paramaters.Status,
                        FirstName = paramaters.FirstName,

                    });
                default:
                    return Url.Link("GetAllActiveProjects", new
                    {
                        pageNumber = paramaters.PageNumber,
                        pageSize = paramaters.PageSize,
                        ProjectName = paramaters.ProjectName,
                        StartDate = paramaters.StartDate,
                        FinishDate = paramaters.FinishDate,
                        Status = paramaters.Status,
                        FirstName = paramaters.FirstName,

                    });*/
    }
        }
    