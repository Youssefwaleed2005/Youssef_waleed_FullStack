using Assignment_2.Repo;
using Assignment_2.Services;
using Assignment_3.Models;
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
        public IActionResult GetAll([FromQuery] ProductFilterParams param) 
        {
            return Ok(_productService.GetAll(param));
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
