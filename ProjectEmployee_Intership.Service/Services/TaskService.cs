using Intership_ProjectTeam4.Database;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ProjectUserContext _context;

        public TaskService(ProjectUserContext context)
        {
            _context = context;
        }


        public Task<TasksDto> AddNewTask(AddTaskRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TasksDto> DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TasksDto>> GetAllTasks(GetTaskRequest search)
        {
            throw new NotImplementedException();
        }

        public Task<TasksDto> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TasksDto> UpdateTask(AddTaskRequest request, int id)
        {
            throw new NotImplementedException();
        }
    }
}
