using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tahaluf.LMS.Core.Data
{
    public class Teacher
    {
         
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public float Salary { get; set; }

        public int LoginId { get; set; }
        public virtual Login Login { get; set; }


        public ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}
