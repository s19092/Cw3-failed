using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Enrollment
    {

        public int IdEnrollment { get; set; }
        public int Semester { get; set; }

        public int IdStudy { get; set; }

        public DateTime StartDate { get; set; }

        public Enrollment(List<string> props)
        {

            IdEnrollment = Int32.Parse(props[0]);
            Semester = Int32.Parse(props[1]);
            IdStudy = Int32.Parse(props[2]);
            StartDate = DateTime.Parse(props[3]);

        }        

    }
}
