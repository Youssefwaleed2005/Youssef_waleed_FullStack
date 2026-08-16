using Assignment_2;
using Asp.Versioning;

using Assignment_2.Repo;
using Assignment_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers.v1
{
    
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("/api/v{version:apiVersion}/product")]
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
            //return Ok(_productService.GetAll());
            return Ok(new { Message = "v1 api" });
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            
            //return Ok(_productService.GetProduct(id));
            return Ok(new {Id = id,Title="v1 product title",isShipped=true});
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
