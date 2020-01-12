using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EmployeeWebApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    
    [Authorize]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeBL _employeeBL;
        private readonly IUserService _userService;
        public EmployeesController(EmployeeBL employeeBL,IUserService userService)
        {
            _employeeBL = employeeBL;
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }



        // GET api/employees
        [HttpGet, Route("api/employee")]
        public ActionResult Get()
        {
            try { 
            var employees = _employeeBL.GetEmployees();

            if(employees.Count>0)
            {
                return Ok(employees);
            }
            else return NoContent();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }


        // POST api/values
        [HttpPost,Route("api/employee")]
        public ActionResult Post([FromBody] Employee employee)
        {
            try
            { 
            _employeeBL.PostEmployee(employee);

            return Ok();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

       
    }
}
