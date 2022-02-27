using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Zdjęcie profilowe")]
        [Required]
        public string ImageUrl { get; set; }
        [Display(Name = "Nazwa autora")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public List<Book> Books { get; set; }

    }
}
