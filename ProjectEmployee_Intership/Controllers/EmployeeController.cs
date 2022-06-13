using Microsoft.AspNetCore.Mvc;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;
using ProjectEmployee_Intership.Dto;
using ProjectEmployee_Intership.Core.Models.Dto;
using Microsoft.AspNetCore.Authorization;

namespace ProjectEmployee_IntershipAPI.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AddEmployeeDto>>>> AddEmployee(AddEmployeeDto addEmployee)
        {
            return Ok(await _employeeService.AddEmployee(addEmployee));
        }
        [HttpPost("AddEmployee")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> UpdateEmployee(UpdateEmployeeDto updatedEmployee)
        {
            return Ok(await _employeeService.UpdateEmployee(updatedEmployee));
        }


       
       

    }

    }

