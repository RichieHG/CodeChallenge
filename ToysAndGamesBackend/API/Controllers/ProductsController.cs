using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productApplication;

        public ProductsController(IProductService productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetProduct([FromRoute] int productId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO newProduct)
        {
           _productApplication.CreateProduct(newProduct);
            return Ok();
        }

        [HttpPut]
        [Route("{productId}")]
        public IActionResult UpdateProduct([FromRoute]int productId)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{productId}")]
        public IActionResult DeleteProudct([FromRoute] int productId)
        {
            return Ok();
        }
    }
}
