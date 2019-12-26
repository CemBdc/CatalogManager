using CatalogManager.Business.Contracts;
using CatalogManager.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CatalogManager.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        /// <summary>
        /// Creates the product data
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Post
        ///     {
        ///        "Code": "EXJHS",
        ///        "Name": "Product3",
        ///        "Picture": "http://bb.com",
        ///        "Price": 152
        ///     }
        ///
        /// </remarks>
        /// <param name="productData"></param>
        [HttpPost]
        [MapToApiVersion("1")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Creates the product data", Description = "Returns newly created productData")]
        [SwaggerResponse(200, "Everything worked and returns the newly created product")]
        [SwaggerResponse(400, "If there is any error while creating product")]
        public async Task<ActionResult<GetProductDto>> Post([FromBody] AddProductDto productData)
        {
            await _product.Add(productData);
            return Ok(productData);
        }

        [HttpGet("{code}")]
        [MapToApiVersion("1")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Gets the product data by code")]
        [SwaggerResponse(200, "Everything worked and returns the product")]
        [SwaggerResponse(204, "There is no product with that code")]
        public async Task<ActionResult<GetProductDto>> Get(string code)
        {
            var product = await _product.GetProductByCode(code);
            return Ok(product);
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "value";
        }

        #region Versioned HealthCheck
        [HttpGet]
        [MapToApiVersion("1")]
        [Route("HealthCheck")]
        public ActionResult<IEnumerable<string>> HealthCheckV1()
        {
            return new string[] { "value1", "value1" };
        }

        [HttpGet]
        [MapToApiVersion("2")]
        [Route("HealthCheck")]
        public ActionResult<IEnumerable<string>> HealthCheckV2()
        {
            return new string[] { "value2", "value2" };
        } 
        #endregion
    }
}