using KASHOP.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Areas.Customer
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult GetAll() => Ok(_categoryService.GetAll());

        [HttpGet("{ID}")]
        public IActionResult GetByID([FromRoute] int ID)
        {
            var category = _categoryService.GetByID(ID);
            if (category is null) return NotFound();
            return Ok(category);
        }
    }
}
