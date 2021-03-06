using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEmployee_intership.Database;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_Intership.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly ProjectUserContext _context;
        private readonly IMapper _mapper;

        public RoleService(ProjectUserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<RoleDto> AddNewRole(AddRoleRequest newRole)
        {
                var role = _mapper.Map<Role>(newRole);
                if (await RoleExist(newRole))
                {
                    throw new ArgumentException("Role exist!");
                }
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> GetById(int id)
        {
            var role = await _context.Roles.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (role == null)
            {
                throw new ArgumentException("Role doesn't exist!");
            }
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<List<RoleDto>> GetRole()
        {
           
                var roles = await _context.Roles.Include(x => x.Users).Where(x => !x.IsDeleted).ToListAsync();
                if (roles == null)
                {
                    throw new ArgumentException("Roles doesn't exist!");
                }
                return _mapper.Map<List<RoleDto>>(roles);

        }
        private async Task<bool> RoleExist(AddRoleRequest role)
        {
            var roleExist = await _context.Roles.FirstOrDefaultAsync(x => x.Name.Contains(role.Name));
            if (roleExist != null)
            {
                return true;
            }
            return false;
        }
    }
}
