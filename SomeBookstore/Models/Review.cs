using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Książka jest wymagana")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required(ErrorMessage = "Recenzant jest wymagany")]
        public string ReviewerName { get; set; }
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Ocena jest wymagana")]
        public decimal Rating { get; set; }   
        
        public string RatingString
        {
            get
            {
                return Rating > 0 ? $"{Math.Round(Rating, 2)} / 10" : "Brak";
            }
        }
    }
}
