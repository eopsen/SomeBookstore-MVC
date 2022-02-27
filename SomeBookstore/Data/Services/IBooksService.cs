using SomeBookstore.Data.ViewModels;
using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task<Book> UpdateAsync(int id, Book newBook);
        Task DeleteAsync(int id);

        Task<BookDropdownsViewModel> GetNewBookDropdownsValues();
        Task AddNewBookAsync(BookViewModel newBook);
        Task UpdateBookAsync(BookViewModel data);
    }
}
