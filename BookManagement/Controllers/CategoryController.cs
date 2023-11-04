using Microsoft.AspNetCore.Mvc;
using Service;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] string name)
        {
            _categoryService.Create(name);
            return Ok();
        }

    }
}
