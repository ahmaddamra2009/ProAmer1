using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAmer1.Models
{
    public class User
    {
        public int UserId { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }

    }
}
