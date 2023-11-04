﻿using Data.Context;
using Data.Entities;
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

        public List<Book> getAllBooks()
        {
            return _context.Books.ToList();
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
    }
}
