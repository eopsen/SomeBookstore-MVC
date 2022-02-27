using Microsoft.EntityFrameworkCore;
using SomeBookstore.Data.ViewModels;
using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.Services
{
    public class BooksService : IBooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book Book)
        {
            await _context.Books.AddAsync(Book);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewBookAsync(BookViewModel data)
        {
            var newBook = new Book()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageURL,
                AuthorId = data.AuthorId,
                PublisherId = data.PublisherId,
                BookCategory = data.BookCategory,
                ReleaseDate = data.ReleaseDate
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBookAsync(BookViewModel data)
        {
            var bookEntity = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (bookEntity != null)
            {
                bookEntity.Name = data.Name;
                bookEntity.Description = data.Description;
                bookEntity.Price = data.Price;
                bookEntity.ImageUrl = data.ImageURL;
                bookEntity.AuthorId = data.AuthorId;
                bookEntity.PublisherId = data.PublisherId;
                bookEntity.BookCategory = data.BookCategory;
                bookEntity.ReleaseDate = data.ReleaseDate;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var Book = await _context.Books.FirstOrDefaultAsync(r => r.Id == id);
            _context.Books.Remove(Book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .OrderBy(r => r.Id)
                .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (book != null)
            {
                book.Reviews = _context.Reviews
                    .Where(b => b.BookId == id)
                    .ToList();
            }

            return book;
        }

        public async Task<BookDropdownsViewModel> GetNewBookDropdownsValues()
        {            
            return new BookDropdownsViewModel() { 
                Authors = await _context.Authors.OrderBy(a => a.FullName).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(a => a.Name).ToListAsync()
            };
        }

        public async Task<Book> UpdateAsync(int id, Book newBook)
        {
            _context.Update(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }
    }
}
