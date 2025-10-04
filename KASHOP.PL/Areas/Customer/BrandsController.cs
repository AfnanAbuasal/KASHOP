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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("")]
        public IActionResult GetAll() => Ok(_brandService.GetAll(true));

        [HttpGet("{ID}")]
        public IActionResult GetByID([FromRoute] int ID)
        {
            var brand = _brandService.GetByID(ID);
            if (brand is null) return NotFound();
            return Ok(brand);
        }
    }
}
