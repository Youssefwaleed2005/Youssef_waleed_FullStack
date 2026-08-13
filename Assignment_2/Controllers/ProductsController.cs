using Assignment_2.Repo;
using Assignment_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductServices _productService;

        public ProductsController(IProductServices productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            
            return Ok(_productService.GetProduct(id));
        }

        [HttpPost ("add")]
        public IActionResult CreateItem([FromBody] Product product)
        {
           
            return Created($"/api/Products/{product.Id}",_productService.CreateProduct(product));
        }

        //[HttpPut ("{id}")]
         
        //public IActionResult ReplaceItem(int id, [FromBody] Product newProduct)
        //{
        //    var product = _products.FirstOrDefault(t => t.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _products.Remove(product);
        //    _products.Add(newProduct);
        //    return Ok(newProduct);

        //}

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            if (_productService.DeleteProduct(id))
            {
                return NoContent();
            }
            else return NotFound();

        }
    }

}
