using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.NewFolder
{
    public class Student
    {

        public int IdStudent { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String IndexNumber { get; set; }

        public Student(List<string> props)
        {

            IdStudent = Int32.Parse(props[0]);
            FirstName = props[1];
            LastName = props[2];
            IndexNumber = props[3];

        }

    }
}
