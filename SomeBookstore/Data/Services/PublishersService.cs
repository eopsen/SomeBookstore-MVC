using Microsoft.EntityFrameworkCore;
using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.Services
{
    public class PublishersService : IPublishersService
    {
        private readonly AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Publisher Publisher)
        {
            await _context.Publishers.AddAsync(Publisher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Publisher = await _context.Publishers.FirstOrDefaultAsync(r => r.Id == id);
            _context.Publishers.Remove(Publisher);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _context.Publishers
                .OrderBy(r => r.Id)
                .ToListAsync();
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            return await _context.Publishers.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Publisher> UpdateAsync(int id, Publisher newPublisher)
        {
            _context.Update(newPublisher);
            await _context.SaveChangesAsync();
            return newPublisher;
        }
    }
}
