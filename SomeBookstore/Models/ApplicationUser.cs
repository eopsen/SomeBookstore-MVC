using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
