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
        public abstract IEnumerable<Book> getAllBooks();

        public abstract Book getBook(int id);
    }
}
