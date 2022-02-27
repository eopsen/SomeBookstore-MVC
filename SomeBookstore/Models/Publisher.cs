using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required]
        public string ImageUrl { get; set; }
        [Display(Name = "Nazwa")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
