using AutoMapper;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Entities;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_Intership.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee)
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();
            Employee employee = _mapper.Map<Employee>(AddEmployee);
            _context.Employee.Add(addEmployee);
            await _context.SaveChangesAsync();
            response.Data= await _context.addEmployee.Select(uint)
        }
    }

