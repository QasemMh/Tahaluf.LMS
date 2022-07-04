using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tahaluf.LMS.Core.Data
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Login> Logins { get; set; }


    }
}