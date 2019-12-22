using CatalogManager.Business.Contracts;
using CatalogManager.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CatalogManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductDto productData)
        {
            await _product.Add(productData);
            return Ok();
        }
    }
}