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
        public IActionResult addCategory([FromQuery(Name = "name")] string name)
        {
            _categoryService.create(name);
            return Ok();
        }

    }
}
