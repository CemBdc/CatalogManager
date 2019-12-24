using CatalogManager.Business.Contracts;
using CatalogManager.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CatalogManager.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

        [HttpGet]
        [MapToApiVersion("1")]
        [Route("GetValues")]
        public ActionResult<IEnumerable<string>> GetV1Values()
        {
            return new string[] { "value1", "value1" };
        }

        [HttpGet]
        [MapToApiVersion("2")]
        [Route("GetValues")]
        public ActionResult<IEnumerable<string>> GetV2Values()
        {
            return new string[] { "value2", "value2" };
        }
    }
}