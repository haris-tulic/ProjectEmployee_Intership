using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEmployee_intership.Database;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;


namespace ProjectEmployee_Intership.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ProjectUserContext _context;
        private IMapper _mapper;
    
     
        public Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetEmployeeDto>> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetEmployeeDto>> GetEmployeeById(int id)
        {
            var response = new ServiceResponse<GetEmployeeDto>();
            try
            {
                Employee employee = await _context.Employees
                    .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
                if(employee == null)
                {
                    response.Success = false;
                    response.Message = "Employee not found!";
                    return response;
                }
                response.Data = _mapper.Map<GetEmployeeDto>(employee);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
       










