using DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBookService
    {
        public Task<bool> saveBookAsync(CreateBookDTO request);
    }
}
