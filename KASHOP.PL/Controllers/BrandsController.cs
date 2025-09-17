using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("")]
        public IActionResult GetAll() => Ok(_brandService.GetAll());

        [HttpGet("{ID}")]
        public IActionResult GetByID([FromRoute] int ID)
        {
            var brand = _brandService.GetByID(ID);
            if (brand is null) return NotFound();
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var ID = _brandService.Create(request);
            return Ok(CreatedAtAction(nameof(GetByID), new { ID }));
        }

        [HttpPatch("{ID}")]
        public IActionResult Update([FromRoute] int ID, [FromBody] BrandRequest request)
        {
            var updated = _brandService.Update(ID, request);
            return updated > 0 ? Ok() : NotFound();
        }

        [HttpPatch("ToggleStatus/{ID}")]
        public IActionResult ToggleStatus([FromRoute] int ID)
        {
            var statusUpdated = _brandService.ToggleStatus(ID);
            return statusUpdated ? Ok(new { message = "Status Toggled!" }) : NotFound(new { message = "Brand Not Found." });
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete([FromRoute] int ID)
        {
            var deleted = _brandService.Delete(ID);
            return deleted > 0 ? Ok() : NotFound();
        }
    }
}
