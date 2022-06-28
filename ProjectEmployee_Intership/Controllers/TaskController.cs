using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_IntershipAPI.Controllers
{
    [Authorize (Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<TasksDto>>> GetAllTasksByParamaters([FromQuery] GetTaskRequest search)
        {
            var response = await _service.GetAllTasksByParamaters(search);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<TasksDto>>> GetAllTasks()
        {
            var response = await _service.GetAllTasks();
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<TasksDto>> GetTaskById(int id)
        {
            var response = await _service.GetTaskById(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResponse<TasksDto>>> AddNewTask(AddTaskRequest newTask)
        {
            var response = await _service.AddNewTask(newTask);

            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<TasksDto>> UpdateTask(AddTaskRequest newTask, int taskId)
        {
            var response = await _service.UpdateTask(newTask, taskId);

            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<TasksDto>> Delete(int taskId)
        {
            var response = await _service.DeleteTask(taskId);

            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<TasksDto>> AssingTaskToUser(int projectId, int userId, int taskId)
        {
            var response = await _service.AssingTaskToUser(userId, projectId, taskId);

            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<TasksDto>> FinishTask(int id)
        {
            var response = await _service.FinishTask(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
