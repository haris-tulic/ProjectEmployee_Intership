using AutoMapper;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_Intership
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
            CreateMap<Role,RoleDto>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();

            CreateMap<AddRoleRequest, Role>().ReverseMap();
                

            CreateMap<GetUserRequest,User >().ReverseMap();
            CreateMap<AddUserRequest, User>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();

            CreateMap<AddProjectRequest, Project>().ReverseMap();
            CreateMap<Project, GetProjectRequest>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();


            CreateMap<AddEmployeeDto, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<GetEmployeeDto, Employee>().ReverseMap();
        }
    }
}
