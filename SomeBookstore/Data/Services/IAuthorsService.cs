using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.Services
{
    public interface IAuthorsService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task AddAsync(Author review);
        Task<Author> UpdateAsync(int id, Author newReview);
        Task DeleteAsync(int id);

    }
}
