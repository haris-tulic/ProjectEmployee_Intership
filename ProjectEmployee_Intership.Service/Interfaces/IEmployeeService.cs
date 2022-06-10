using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Models;

namespace ProjectEmployee_Intership.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto addEmployee);
        Task<ServiceResponse<List<GetEmployeeDto>>> UpdateEmployee(UpdateEmployeeDto editEmployee);
        Task<ServiceResponse<List<GetEmployeeDto>>> DeleteEmployee(int id);
        Task<ServiceResponse<GetEmployeeDto>> GetEmployee(int id);
    }
}
