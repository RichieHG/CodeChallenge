using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() => Ok(await _productsService.Get());

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            try
            {
                var product = await _productsService.Get(id);
                return Ok(product);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO newProduct)
        {
            await _productsService.Add(newProduct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]int id, [FromBody] ProductDTO product)
        {
            try
            {
                await _productsService.Update(id, product);
                return Ok(null);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProudct([FromRoute] int id)
        {
            try
            {
                await _productsService.Delete(id);
                return Ok(null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
