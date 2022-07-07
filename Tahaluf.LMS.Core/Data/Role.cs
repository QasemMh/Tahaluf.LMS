using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tahaluf.LMS.Core.Data
{
    public class Role
    {
        
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Login> Logins { get; set; }


    }
}