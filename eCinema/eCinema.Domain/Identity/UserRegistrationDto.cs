using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCinema.Domain.Identity
{
    public class UserRegistrationDto
    {
        [EmailAddress(ErrorMessage ="Invalid email")]
        [Required(ErrorMessage ="Email field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confrim password field is required")]
        [Compare("Password",ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
