using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EmployeeWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeBL _employeeBL;
        public EmployeesController(EmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }

        // GET api/employees
        [HttpGet]
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
        [HttpPost]
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
