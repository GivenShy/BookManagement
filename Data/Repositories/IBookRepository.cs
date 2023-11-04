using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IBookRepository
    {
        public Task<List<Book>> getAllBooks();
        public Book getBook(int id);
        public Task saveAsync(Book book);
        public Task<List<Book>> getAllBooksAsync(int page,int pageSize);
        public Task<List<Book>> search(string search); 
    }
}
