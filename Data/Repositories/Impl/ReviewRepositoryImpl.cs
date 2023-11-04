using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Impl
{
    public class ReviewRepositoryImpl : IReviewRepository
    {
        private readonly BookManagementContext _context;

        public ReviewRepositoryImpl(BookManagementContext context)
        {
            _context = context;
        }

        public async Task<double> AvgRating(int bookId)
        {
            return await _context.Reviews.Where(r => r.BookId == bookId).AverageAsync(r => r.Rating);
        }

        public Task<Review> GetByEmailAndID(string email, int id)
        {
            return _context.Reviews.Where(r=>r.email == email&&r.bookId == id).FirstOrDefaultAsync();
        }

        public Task Save(Review review)
        {
            _context.Reviews.Add(review);
            return _context.SaveChangesAsync();
            
        }
    }
}
