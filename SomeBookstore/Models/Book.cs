using SomeBookstore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public BookCategory BookCategory { get; set; }

        public decimal? AverageRating { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public List<Review> Reviews { get; set; }

        public string AverageRatingString
        {
            get
            {
                return AverageRating.HasValue ? Math.Round(AverageRating.Value, 2).ToString() + " / 10" : "Brak";
            }
        }
    }
}
