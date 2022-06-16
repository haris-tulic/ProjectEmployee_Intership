using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Models;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee);
        Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployee();
        Task<ServiceResponse<GetEmployeeDto>> GetEmployeeById(int id);
        Task<ServiceResponse<GetEmployeeDto>> UpdateEmployee(AddEmployeeDto updateEmployee, int id);
        Task<ServiceResponse<GetEmployeeDto>> DeleteEmployee(int id);
    }
}
