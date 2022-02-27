using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.ViewModels
{
    public class BookDropdownsViewModel
    {
        public BookDropdownsViewModel()
        {
            Authors = new List<Author>();
            Publishers = new List<Publisher>();
        }

        public List<Author> Authors { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}
