using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_Intership.Controllers
{
   // [Authorize(Roles = "Admin")]
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet ("[action]")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> GetAllEmploye()
        {
            var response = await _employeeService.GetAllEmployee();
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);


        }
        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> AddEmployee(AddEmployeeDto newEmployee)
        {
            var response = await _employeeService.AddEmployee(newEmployee);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> GetEmployeById(int id)
        {
            var response = await _employeeService.GetEmployeeById(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);


        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> DeleteEmployee(int id)
        {
            var response = await _employeeService.DeleteEmployee(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);    
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> UpdateEmployee(AddEmployeeDto updateEmployee, int id)
        {
            var response = await _employeeService.UpdateEmployee(updateEmployee, id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }




    }

}



