using AutoMapper;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Mapper.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddTaskRequest, Tasks>().ReverseMap();
            CreateMap<Tasks, GetTaskRequest>().ReverseMap();
            CreateMap<Tasks, TasksDto>().ReverseMap();

            CreateMap<Project,GetProjectRequest>().ReverseMap();
            CreateMap<AddProjectRequest, Project>().ReverseMap();
            CreateMap<ProjectDto, Project>().ReverseMap();

            CreateMap<Role, GetRoleRequest>().ReverseMap();
            CreateMap<AddRoleRequest, Role>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
