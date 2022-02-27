using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.Services
{
    public interface IReviewsService
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(int id);
        Task AddAsync(Review review);
        Task<Review> UpdateAsync(int id, Review newReview);
        Task DeleteAsync(int id);

    }
}
