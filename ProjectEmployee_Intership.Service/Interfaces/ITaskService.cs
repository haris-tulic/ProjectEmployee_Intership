using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Models;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    public interface ITaskService
    {
        Task<List<TasksDto>> GetAllTasks();

        Task<List<TasksDto>> GetAllTasksByParamaters(GetTaskRequest search);
        Task<TasksDto> GetTaskById(int id);
        Task<ServiceResponse<TasksDto>> AddNewTask(AddTaskRequest request);
        Task<TasksDto> UpdateTask(AddTaskRequest request, int id);
        Task<TasksDto> DeleteTask(int id);
        Task<TasksDto> AssingTaskToUser(int userId, int projectId, int taskId);
        Task<TasksDto> FinishTask(int id);
    }
}
