using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Imię i nazwisko")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Adres email")]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Potwierdź hasło")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie pasują")]
        public string ConfirmPassword { get; set; }
    }
}
