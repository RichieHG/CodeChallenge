using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : Controller
    {
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
        public IActionResult CreateProduct()
        {
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
