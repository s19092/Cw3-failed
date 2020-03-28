using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.NewFolder;
using System.Data.SqlClient;
using WebApplication1.Models;

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
            String[] col = { "firstname" };
            return Ok(new Student(QuerryForParam("SELECT * FROM STUDENT", col ,null )));

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

        [HttpGet("{indexNumber}")]
        public IActionResult getStudent(string indexNumber)
        {

            string querry = "select * from enrollment e inner join student s on e.idenrollment = s.idenrollment where s.IndexNumber = @index;";
            string[] cols = { "idenrollment", "semester", "idstudy", "startdate" };
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("index", indexNumber);
            Enrollment enrollment = new Enrollment( QuerryForParam(querry,cols,parameters));
            return Ok(enrollment);
        }


        private List<string> QuerryForParam(string querry,string[] columnNames,Dictionary<string,string> parameters)
        {

            string conStrin = "Data Source=db-mssql;Initial Catalog=s19092;Integrated Security=True";
            var list = new List<string>();

            using (SqlConnection con = new SqlConnection(conStrin))
            using (SqlCommand com = new SqlCommand())
            {

                com.Connection = con;
                com.CommandText =(querry);

                if(parameters != null)
                {
                    foreach (KeyValuePair<string, string> param in parameters)
                        com.Parameters.AddWithValue(param.Key, param.Value);
                
                }

                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {

                    foreach (string col in columnNames)
                        list.Add("'" + col + "'=" +reader[col].ToString());
                }
                return (list);
               }


        }

       
    }

}