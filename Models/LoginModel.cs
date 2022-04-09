using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class LoginModel : IdentityUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Username Or Password")]
        public string EmailOrUsername { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Please provide a valid password to get accessed.")]
        public string Password { get; set; }
    }
}
