using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetRole();
        Task<RoleDto> GetById(int id);
        Task<RoleDto> AddNewRole(AddRoleRequest newRole);
    }
}
