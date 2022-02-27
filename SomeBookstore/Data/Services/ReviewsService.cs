using Microsoft.EntityFrameworkCore;
using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly AppDbContext _context;

        public ReviewsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            await CalculateAverageRating(review.BookId);
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            await CalculateAverageRating(review.BookId);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews
                .Include(r => r.Book)
                .OrderBy(r => r.Id)
                .ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Review> UpdateAsync(int id, Review newReview)
        {
            _context.Update(newReview);
            await _context.SaveChangesAsync();
            await CalculateAverageRating(newReview.BookId);
            return newReview;
        }

        private async Task CalculateAverageRating(int bookId)
        {
            var bookReviews = await _context.Reviews
                .Where(r => r.BookId == bookId)
                .ToListAsync();

            var reviewsRatingSum = bookReviews.Sum(r => r.Rating);
            var reviewsCount = bookReviews.Count();

            var averageRating = 0m;
            if (reviewsCount > 0)
            {
                averageRating = Math.Round(reviewsRatingSum / reviewsCount, 2);
            }

            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null) return;

            book.AverageRating = averageRating;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
