using Data.Entities;
using Data.Repositories;
using DTO.Requests;
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
        public BookServiceImpl(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> saveBookAsync(CreateBookDTO request)
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
            var result = new StringBuilder();
            using(var stream =request.PdfFile.OpenReadStream())
            {
                book.Content = ExtractTextFromPdf(stream);
            }
            book.Content = result.ToString();
            await _bookRepository.saveAsync(book);
            return true;
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
