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
        public Task<List<Book>> GetAllBooks();
        public Book GetBook(int id);
        public Task SaveAsync(Book book);
        public Task<List<Book>> GetAllBooksAsync(int page,int pageSize);
        public Task<List<Book>> Search(string search); 
        public void Delete(int id);
        public void Update(Book book);
    }
}
