﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.NewFolder;

namespace WebApplication1.DAL
{
    public interface IDbService
    {

        public IEnumerable<Student> GetStudents();

    }
}
