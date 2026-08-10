using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>();
        private static int _lastId = 1;
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _products.FirstOrDefault(t => t.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Product product)
        {
            product.Id = _lastId++;
            _products.Add(product);
            return Created();
        }

        [HttpPut ("{id}")]
         
        public IActionResult ReplaceItem(int id, [FromBody] Product newProduct)
        {
            var product = _products.FirstOrDefault(t => t.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            _products.Add(newProduct);
            return Ok(newProduct);

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteItem(int id)
        {
            var product = _products.FirstOrDefault(t => t.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            _lastId -= 1;
            return NoContent();
        }
    }

}
