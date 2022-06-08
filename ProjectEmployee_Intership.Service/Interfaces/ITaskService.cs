﻿using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    internal interface ITaskService
    {
        Task<List<TasksDto>> GetAllTasks(GetTaskRequest search);
        Task<TasksDto> GetTaskById(int id);
        Task<TasksDto> AddNewTask(AddTaskRequest request);
        Task<TasksDto> UpdateTask(AddTaskRequest request, int id);
        Task<TasksDto> DeleteTask(int id);

    }
}