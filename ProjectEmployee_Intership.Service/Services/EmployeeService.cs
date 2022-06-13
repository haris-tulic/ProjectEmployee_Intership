using AutoMapper;
using ProjectEmployee_intership.Database;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_Intership.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ProjectUserContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(ProjectUserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetEmployeeDto>>> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetEmployeeDto>> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetEmployeeDto>>> UpdateEmployee(UpdateEmployeeDto editEmployee)
        {
            throw new NotImplementedException();
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

