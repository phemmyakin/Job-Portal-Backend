using AutoMapper;
using Jobportal.Models;
using Jobportal.Services;
using JobPortal.Data.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JobPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]EmployeeDto employeeParam)
        {
            var user = _employeeRepository.Authenticate(employeeParam.Username, employeeParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }



        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]EmployeeDto employeeDto)
        {
            // map dto to entity
            var employee = _mapper.Map<Employee>(employeeDto);

            try
            {
                // save 
                _employeeRepository.CreateEmployee(employee, employeeDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }




        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]EmployeeDto employeeDto)
        {
            // map dto to entity and set id
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.EmployeeId = id;

            try
            {
                // save 
                _employeeRepository.UpdateEmployee(employee, employeeDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }

}
