using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Requests
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile PdfFile { get; set; }
    }
}
