using System.ComponentModel.DataAnnotations;

namespace Tahaluf.LMS.Core.Data
{
    public class TeacherCourse
    {
       
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public virtual int TeacherId { get; set; }
        public Course Course { get; set; }
        public virtual int CourseId { get; set; }   
    }
}