using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        [HttpGet]
        public string getStudents(String orderBy)
        {


            String result = $"DZBAN, drugi, Andrzejweski sort={orderBy}";
            return result;

        }
        

        [HttpGet("{id}")]
        public IActionResult getStudent(int id)
        {
            if(id == 1)
                return Ok("DZBAN");
            if (id == 2)
                return Ok("drugi");
            if (id == 3)
                return Ok("trzeci");
            else
                return NotFound("Wrong id");
        }
    }
}