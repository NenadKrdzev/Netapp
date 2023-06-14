using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCinema.Domain.Identity
{
    public class UserLoginDto
    {
        [Required(ErrorMessage ="Email field is required")]
        [EmailAddress(ErrorMessage ="Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remeber me")]
        public bool RememberMe { get; set; }
    }
}
