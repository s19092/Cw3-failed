using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.NewFolder;
using System.Data.SqlClient;

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
            return QuerryFor("SELECT * FROM STUDENT", col ,null );

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
            String[] colname = { "IdEnrollment","Semester","IdStudy","StartDate" }; 
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("index",indexNumber);
            return QuerryFor("SELECT * FROM Enrollment e INNER JOIN Student s ON e.IdEnrollment = s.IdEnrollment"
                + " WHERE IndexNumber = @index",colname,dict);
        }


        private IActionResult QuerryFor(string querry,string[] colname,Dictionary<string,string> param)
        {

            string conStrin = "Data Source=db-mssql;Initial Catalog=s19092;Integrated Security=True";
            var st = new List<string>();

            using (SqlConnection con = new SqlConnection(conStrin))
            using (SqlCommand com = new SqlCommand())
            {
                
                


                com.Connection = con;
                com.CommandText = querry;
                if (param != null)
                {

                    foreach (KeyValuePair<string, string> item in param)
                        com.Parameters.AddWithValue(item.Key, item.Value);
                         
             
                }
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[colname[0]] == DBNull.Value)
                    {


                    }
                    for(int op = 0; op < colname.Length; ++op)
                        st.Add(colname[op]+"=" +dr[colname[op]].ToString());


                }
                if(st.Count>0)
                return Ok(st);
            }

            return NotFound();

        }
    }

}