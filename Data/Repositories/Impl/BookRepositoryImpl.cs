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

        public void delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == id);
            if(book == null) 
            {
                throw new ArgumentException("The book with this id does not exist");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Task<List<Book>> getAllBooks()
        {
            return _context.Books.ToListAsync();
        }

        public Task<List<Book>> getAllBooksAsync(int page, int pageSize)
        {
            return _context.Books.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public Book getBook(int id)
        {
            return _context.Books.SingleOrDefault(book => book.Id == id);
        }

        public async Task saveAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> search(string search)
        {
            search = "%" + search + "%";
            return await _context.Books.Where(obj =>
            EF.Functions.Like(obj.Author, search) ||
            EF.Functions.Like(obj.Title, search) ||
            EF.Functions.Like(obj.Content, search)).ToListAsync();
        }

        public async void update(Book book)
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
