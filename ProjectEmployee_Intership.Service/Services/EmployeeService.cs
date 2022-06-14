using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEmployee_intership.Database;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;


namespace ProjectEmployee_Intership.Service.Services
{

    public class EmployeeService : IEmployeeService
    {
        private ProjectUserContext _context;
        private IMapper _mapper;

        public async Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee)
        {

            {
                var response = new ServiceResponse<List<GetEmployeeDto>>();
                var Employee = _mapper.Map<Employee>(addEmployee);
                _context.Employees.Add(Employee);
                await _context.SaveChangesAsync();
                response.Data = await _context.Employees.Select(u => _mapper.Map<GetEmployeeDto>(u)).ToListAsync();
                return response;
            }
        }

        public async Task<ServiceResponse<GetEmployeeDto>> GetAllEmployee()
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();
            var dbEmployee = await _context.Employees.Where(c => c.IsDeleted == false).ToListAsync();
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
       


/*  public async Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee)
  {
      var response = new ServiceResponse<List<GetEmployeeDto>>();
      Employee employee = _mapper.Map<Employee>(AddEmployee);
      _context.Employee.Add(addEmployee);
      await _context.SaveChangesAsync();
      response.Data= await _context.addEmployee.Select(uint)
  }
}*/

