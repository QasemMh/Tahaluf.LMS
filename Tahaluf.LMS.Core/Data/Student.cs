﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tahaluf.LMS.Core.Data
{
    public class Student
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}