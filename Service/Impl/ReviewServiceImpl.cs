using Data.Entities;
using Data.Repositories;
using DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class ReviewServiceImpl : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IBookRepository _bookRepository;

        public ReviewServiceImpl(IReviewRepository repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public async void CreateReview(CreateReviewDTO createReviewDto)
        {
            if( _bookRepository.getBook(createReviewDto.bookId)!=null)  
            {
                if (await _repository.GetByEmailAndID(createReviewDto.email, createReviewDto.bookId) != null)
                {
                    Review review = new Review();
                    review.Date = DateTime.Now;
                    review.Email = createReviewDto.email;
                    review.BookId = createReviewDto.bookId;
                    review.Comment = createReviewDto.comment;
                    review.Rating = createReviewDto.rating;
                    await _repository.Save(review);
                }
                else
                {
                    throw new ArgumentException("There is already one review");
                }
            }
            else
            {
                throw new ArgumentException("Book with that Id does not exist");
            } 
        }
    }
}
