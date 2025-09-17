using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var ID = _categoryService.Create(request);
            return Ok(CreatedAtAction(nameof(GetByID), new { ID }));
        }

        [HttpPatch("{ID}")]
        public IActionResult Update([FromRoute] int ID, [FromBody] CategoryRequest request)
        {
            var updated = _categoryService.Update(ID, request);
            return updated > 0 ? Ok() : NotFound();
        }

        [HttpPatch("ToggleStatus/{ID}")]
        public IActionResult ToggleStatus([FromRoute] int ID)
        {
            var statusUpdated = _categoryService.ToggleStatus(ID);
            return statusUpdated ? Ok(new { message = "Status Toggled!" }) : NotFound(new { message = "Category Not Found." });
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete([FromRoute] int ID)
        {
            var deleted = _categoryService.Delete(ID);
            return deleted > 0 ? Ok() : NotFound();
        }
    }
}
