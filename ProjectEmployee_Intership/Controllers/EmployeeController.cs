using Microsoft.AspNetCore.Mvc;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ProjectEmployee_Intership.Service.Services;
using ProjectEmployee_Intership.Core.Models.Dto;
using System.Security.Claims;

namespace ProjectEmployee_Intership.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> GetAllEmploye()
        {
            return Ok(await _employeeService.GetAllEmployee());


        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> AddCharacter(AddEmployeeDto newEmployee)
        {
            return Ok(await _employeeService.AddEmployee(newEmployee));
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> GetEmployeById(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));


        }
















    }

}



