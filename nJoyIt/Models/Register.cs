using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nJoyIt.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [UIHint("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You have to confirm the password!")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; } = "/";

    }
}
