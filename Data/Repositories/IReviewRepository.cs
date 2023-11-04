using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IReviewRepository
    {
        public Task<Review> GetByEmailAndID(string email,int id);
        public Task Save(Review review);
        public Task<double> AvgRating(int bookId);
    }
}
