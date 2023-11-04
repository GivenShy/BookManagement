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
    public class BookRepositoryImpl : IBookRepository
    {
        private readonly BookManagementContext _context;

        public BookRepositoryImpl(BookManagementContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == id);
            if(book == null) 
            {
                throw new ArgumentException("The book with this id does not exist");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Task<List<Book>> GetAllBooks()
        {
            return _context.Books.ToListAsync();
        }

        public Task<List<Book>> GetAllBooksAsync(int page, int pageSize)
        {
            return _context.Books.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public Book GetBook(int id)
        {
            return _context.Books.SingleOrDefault(book => book.Id == id);
        }

        public async Task SaveAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> Search(string search)
        {
            search = "%" + search.ToLower() + "%";
            return await _context.Books.Where(obj =>
            EF.Functions.Like(obj.Author.ToLower(), search) ||
            EF.Functions.Like(obj.Title.ToLower(), search) ||
            EF.Functions.Like(obj.Content.ToLower(), search)).ToListAsync();
        }

        public async void Update(Book book)
        {
            Book b = _context.Books.SingleOrDefault(b=>b.Id == book.Id);
            if (b == null)
            {
                throw new ArgumentException("Book with this id does not exist");
            }
            b.Title = book.Title;
            b.Content = book.Content;
            b.Author = book.Author;
            Category c = _context.Categories.SingleOrDefault(c => c.Name == book.CategoryName);
            if(c == null)
            {
                throw new ArgumentException("This category does not exist");
            }
            b.Category = book.Category;
            await _context.SaveChangesAsync();
            
        }
    }
}
