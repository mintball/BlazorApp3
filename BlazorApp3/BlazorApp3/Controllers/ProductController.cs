using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareLibrary.Models;
using ShareLibrary.ProductRepositories;

namespace BlazorApp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("All-Products")]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var result = await productRepository.GetAllProductAsync();
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("Single-Product/{id}")]
        public async Task<ActionResult<List<Product>>> GetProductByIdAsync(int id)
        {
            var result = await productRepository.GetProductByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("Add-Product")]
        public async Task<ActionResult<List<Product>>> AddProductAsync(Product model)
        {
            var result = await productRepository.AddProductAsync(model);
            if (result is null) return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update-Product")]
        public async Task<ActionResult<List<Product>>> UpdateProductAsync(Product model)
        {
            var result = await productRepository.UpdateProductAsync(model);
            if (result is null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("Delete-Product/{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProductAsync(int id)
        {
            var result = await productRepository.DeleteProductAsync(id);
            if (result is null) return BadRequest();
            return Ok(result);
        }
    }
        
}
