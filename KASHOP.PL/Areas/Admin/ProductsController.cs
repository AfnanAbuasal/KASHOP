using KASHOP.BLL.Services.Classes;
using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Areas.Admin
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,Super Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public IActionResult GetAll() => Ok(_productService.GetAll());

        [HttpGet("{ID}")]
        public IActionResult GetByID([FromRoute] int ID)
        {
            var product = _productService.GetByID(ID);
            if (product is null) return NotFound();
            return Ok(product);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync([FromForm] ProductRequest productRequest)
        {
            var result = await _productService.CreateWithFile(productRequest);
            return Ok(result);
        }
    }
}
