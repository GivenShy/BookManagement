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

        BookRepositoryImpl(BookManagementContext context)
        {
            _context = context;
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
    }
}
