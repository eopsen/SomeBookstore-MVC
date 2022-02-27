using SomeBookstore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "ImageUrl")]
        [Required]
        public string ImageURL { get; set; }

        [Display(Name = "Data wydania")]
        [Required]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Wybierz kategorię")]
        [Required]
        public BookCategory BookCategory { get; set; }

        [Display(Name = "Wybierz autora")]
        [Required]
        public int AuthorId { get; set; }

        [Display(Name = "Wybierz wydawnictwo")]
        [Required]
        public int PublisherId { get; set; }
    }
}
