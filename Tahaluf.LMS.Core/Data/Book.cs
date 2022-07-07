using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tahaluf.LMS.Core.Data
{
    public class Book
    {

       
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime PublishDate { get; set; }

        
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

    }
}