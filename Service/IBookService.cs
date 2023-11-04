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
        public Task<List<BookDTO>> GetPageAsync(int page, int pageSize);
        public Task<bool> SaveBookAsync(CreateBookDTO request);
        public Task<List<BookDTO>> SearchAsync(string search);
        public void Delete(int id);
        void Update(UpdateBookDTO updateBookDTO);
        
    }
}
