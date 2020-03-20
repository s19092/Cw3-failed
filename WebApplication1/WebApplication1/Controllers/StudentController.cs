using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.NewFolder;

namespace WebApplication1.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IDbService _dbService;

        public StudentController(IDbService dbService)
        {
            _dbService = dbService;

        }
        [HttpGet]
        public IActionResult getStudents(String orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {

            student.IndexNumber = $"s{new Random().Next(1,2000)}";
            return Ok(student);

        }
        
        [HttpPut("{id}")]
        public IActionResult putStudent(int id)
        {
            return Ok("Update succeed " + id);
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id)
        {
            return Ok("Delete succeed " + id);
        }

        [HttpGet("{id}")]
        public IActionResult getStudent(int id)
        {
            return Ok(_dbService);
        }
    }
}