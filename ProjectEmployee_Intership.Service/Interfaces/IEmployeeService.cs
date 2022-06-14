using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Models;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee);
        Task<ServiceResponse<GetEmployeeDto>> GetAllEmployee();
        Task<ServiceResponse<GetEmployeeDto>> GetEmployeeById(int id);
        
    }
}
