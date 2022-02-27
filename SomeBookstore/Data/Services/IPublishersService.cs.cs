using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.Services
{
    public interface IPublishersService
    {
        Task<IEnumerable<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(int id);
        Task AddAsync(Publisher review);
        Task<Publisher> UpdateAsync(int id, Publisher newReview);
        Task DeleteAsync(int id);

    }
}
