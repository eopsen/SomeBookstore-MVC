using Microsoft.EntityFrameworkCore;
using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Author Author)
        {
            await _context.Authors.AddAsync(Author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Author = await _context.Authors.FirstOrDefaultAsync(r => r.Id == id);
            _context.Authors.Remove(Author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors
                .OrderBy(r => r.Id)
                .ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Author> UpdateAsync(int id, Author newAuthor)
        {
            _context.Update(newAuthor);
            await _context.SaveChangesAsync();
            return newAuthor;
        }
    }
}
