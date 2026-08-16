using Asp.Versioning;
using Assignment_2.Repo;
using Assignment_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Runtime.Intrinsics.X86;

namespace Assignment_2.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
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

            return Ok(new { Message = "V2 api" });
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            
            return Ok(new { Id = id,Title="v2 Product title",Status="Delivered",price =40,});
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
