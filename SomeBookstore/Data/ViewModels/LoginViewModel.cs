using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
