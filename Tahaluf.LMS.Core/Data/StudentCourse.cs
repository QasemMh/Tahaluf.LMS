using System.ComponentModel.DataAnnotations;

namespace Tahaluf.LMS.Core.Data
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public virtual int StudentId { get; set; }
        public Course Course { get; set; }
        public virtual int CourseId { get; set; }
    }

}