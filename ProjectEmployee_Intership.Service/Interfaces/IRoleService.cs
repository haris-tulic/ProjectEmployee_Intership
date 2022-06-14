using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetRole();
        Task<RoleDto> GetById(int id);
        Task<RoleDto> AddNewRole(AddRoleRequest newRole);
    }
}
