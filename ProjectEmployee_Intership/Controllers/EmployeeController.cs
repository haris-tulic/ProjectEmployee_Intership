using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Models;
using ProjectEmployee_Intership.Service.Interfaces;
using ProjectEmployee_Intership.Dto;
using ProjectEmployee_Intership.Core.Models.Dto;
using Microsoft.AspNetCore.Authorization;

namespace ProjectEmployee_Intership.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
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



