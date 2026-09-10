using Assignment_2.Repo;
using Assignment_2.Services;
using Assignment_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi;
using Assignment_3.Helper;

namespace Assignment_2.Controllers
{ 
    [Authorize]

    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductServices _productService;
        private readonly IAuthorizationService _authz;

        public ProductsController(IProductServices productService, IAuthorizationService auth)
        {
            _productService = productService;
            _authz = auth;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] ProductFilterParams param)
        {
            return Ok(_productService.GetAll(param));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var data = await _productService.GetProduct(id);
            return Ok(new 
            { 
                ProductId = data.Id,
                Title=data.Title,
                UserId=data.UserId,
                Name=data.User.Name
            
            });
        }

        [HttpPost ("add")]
        [Authorize (Policy = "CanManageProdcuts")]
        public async Task<IActionResult> CreateItem([FromBody] Product product)
        {
           
            return Created($"/api/Products/{product.Id}",await _productService.CreateProduct(product));
        }

       

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanManageProducts")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _productService.DeleteProduct(id))
            {
                return NoContent();
            }
            else return NotFound();

        }

        [Authorize]
        [HttpDelete("/Users/{id}")]
        public async Task<IActionResult> UserDeleteProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
                return NotFound();
            var result = await _authz.AuthorizeAsync(
                User, product, Operations.Delete);
            if (!result.Succeeded)
                return Forbid();

           await _productService.DeleteProduct(id);
            return NoContent();

        }
    }

}
