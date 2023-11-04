using DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookDTO request)
        {
            if (request.PdfFile == null || request.PdfFile.Length == 0)
                return BadRequest("PDF file is not provided or empty.");
            if (request.PdfFile.Length > 5 * 1024 * 1024)
            {
                return BadRequest("Provide smaller file");
            }
            if (!request.PdfFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("The uploaded file is not a PDF.");
            }
            if (!await _bookService.saveBookAsync(request)) {
                return BadRequest("This category does not exist");
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> getAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            if(page < 0 || pageSize < 0)
            {
                return BadRequest("Invalid page info");
            }
            
            return Ok(await _bookService.GetPage(page, pageSize));
        }

            
    }
}
