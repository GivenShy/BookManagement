using Data.Entities;
using Data.Repositories;
using DTO.Requests;
using DTO.Response;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class BookServiceImpl : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReviewRepository _reviewRepository;

        public BookServiceImpl(IBookRepository bookRepository, ICategoryRepository categoryRepository,IReviewRepository reviewRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _reviewRepository = reviewRepository;
        }

        public void Delete(int id)
        {
            _bookRepository.delete(id);
        }

        public async Task<List<BookDTO>> GetPageAsync(int page, int pageSize)
        {
            List<Book> books;
            if(page == 0 && pageSize == 0)
            {
                books = await _bookRepository.getAllBooks();
            }
            else
            {
                books = await _bookRepository.getAllBooksAsync(page, pageSize);
            }
            return await Task<List<BookDTO>>.Factory.StartNew(() =>
            {
                List<BookDTO> res = new List<BookDTO>(books.Count);
                foreach (var book in books)
                {
                    res.Add(convert(book));
                }
                return res;
            });
            
        }

        public async Task<bool> SaveBookAsync(CreateBookDTO request)
        {
            Category category = _categoryRepository.find(request.Category);
            if (category == null)
            {
                return false;     
            }
            Book book = new Book();
            book.Author = request.Author;
            book.Title = request.Title;
            book.Category = category;
            using(var stream =request.PdfFile.OpenReadStream())
            {
                book.Content = ExtractTextFromPdf(stream);
            }
            await _bookRepository.saveAsync(book);
            return true;
        }

        public async Task<List<BookDTO>> SearchAsync(string search)
        {
            List<Book> books = await _bookRepository.search(search); 
            return await Task<List<BookDTO>>.Factory.StartNew(() =>
            {
                List<BookDTO> res = new List<BookDTO>(books.Count);
                foreach (var book in books)
                {
                    res.Add(convert(book));
                }
                return res;
            });
        }

        public void Update(UpdateBookDTO updateBookDTO)
        {
            _bookRepository.update(convert(updateBookDTO));            
        }

        private  BookDTO convert(Book book)
        {
            BookDTO bookDTO = new BookDTO();
            bookDTO.Id = book.Id;
            bookDTO.Title = book.Title;
            bookDTO.Content = book.Content;
            bookDTO.Author = book.Author;
            bookDTO.Category = book.CategoryName;
            bookDTO.AvgRating =_reviewRepository.AvgRating(book.Id).Result;
            return bookDTO;

        }
        private Book convert(UpdateBookDTO bookDTO)
        {
            Book book = new Book();
            book.Id = bookDTO.Id;
            book.Title = bookDTO.Title;
            book.Author = bookDTO.Author;
            using(var stream = bookDTO.PdfFile.OpenReadStream())
            {
                book.Content = ExtractTextFromPdf(stream);
            }
            return book;
        }

        private string ExtractTextFromPdf(Stream pdfStream)
        {
            using (PdfReader pdfReader = new PdfReader(pdfStream))
            {
                var text = new StringBuilder();
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    var strategy = new SimpleTextExtractionStrategy();
                    var currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                    text.Append(currentText);
                }

                return text.ToString();
            }
        }
     
    }
}
