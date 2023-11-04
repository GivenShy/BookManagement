using DTO.Requests;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBookService
    {
        public Task<List<BookDTO>> GetPage(int page, int pageSize);
        public Task<bool> saveBookAsync(CreateBookDTO request);
    }
}
