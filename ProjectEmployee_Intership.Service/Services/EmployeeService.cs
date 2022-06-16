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
        public EmployeeService(ProjectUserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee)
        {

            var response = new ServiceResponse<List<GetEmployeeDto>>();
            try
            {
                var employee = _mapper.Map<Employee>(addEmployee);
                var task = await TaskExist(addEmployee.taskId);
                if (task != null)
                {
                    employee.Tasks = new List<Tasks>();
                    employee.Tasks.Add(task);
                }

                var project = await ProjectExist(addEmployee.projectId);
                if (project != null)
                {
                    employee.Projects = new List<Project>();
                    employee.Projects.Add(project);
                }
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                response.Data = await _context.Employees.Select(u => _mapper.Map<GetEmployeeDto>(u)).ToListAsync();
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                throw new ArgumentException(ex.Message);
            }
        }

        private async Task<Project> ProjectExist(int projectId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId && !p.IsDeleted);
            if (project == null)
            {
                return null;
            }
            return project;
        }

        private async Task<Tasks> TaskExist(int taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && !t.IsDeleted && !t.IsFinished);
            if (task == null)
            {
                return null;
            }
            return task;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> DeleteEmployee(int id)
        {
            var response = new ServiceResponse<GetEmployeeDto>();
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            if (employee == null)
            {
                response.Message = "Employee doesn't exist";
                response.Success = false;
                throw new ArgumentException("Employee doesn't exist");
            }
            employee.IsDeleted = true;
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Data = _mapper.Map<GetEmployeeDto>(employee);
            return response;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployee()
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();


            var dbEmployee = await _context.Employees.Include(e=> e.Tasks).Include(e=> e.Tasks).Where(e=> !e.IsDeleted).ToListAsync();
            if (dbEmployee == null)
            {
                throw new ArgumentException("Employees doesn't exist!");
            }
            response.Data = _mapper.Map<List<GetEmployeeDto>>(dbEmployee);
            response.Success = true;
            return response;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> GetEmployeeById(int id)
        {
            var response = new ServiceResponse<GetEmployeeDto>();
            try
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
                if (employee == null)
                {
                    response.Success = false;
                    response.Message = "Employee not found!";
                    throw new ArgumentException("Employee doesn't exist");
                    return response;
                }
                response.Success = true;
                response.Data = _mapper.Map<GetEmployeeDto>(employee);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> UpdateEmployee(AddEmployeeDto updateEmployee, int id)
        {
            var response = new ServiceResponse<GetEmployeeDto>();
            var employee = _context.Employees.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            _mapper.Map(updateEmployee, employee);
            if (employee == null)
            {
                throw new ArgumentException("Employee doesn't exist");
            }

            var task = await TaskExist(updateEmployee.taskId);
            if (task != null)
            {
                if (!employee.Tasks.Contains(task))
                {
                    employee.Tasks.Add(task);
                }
            }

            var project = await ProjectExist(updateEmployee.projectId);
            if (project != null)
            {
                if (!employee.Projects.Contains(project))
                {
                    employee.Projects.Add(project);
                }
            }

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetEmployeeDto>(employee);
            response.Success = true;
            return response;

        }
    }
}





