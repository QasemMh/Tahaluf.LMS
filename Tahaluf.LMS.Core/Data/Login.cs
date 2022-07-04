using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tahaluf.LMS.Core.Data
{
    public class Login
    {
        
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        //[EmailAddress]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public virtual int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}