using CatalogManager.Business.Contracts;
using CatalogManager.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CatalogManager.UnitTest
{
    public class ProductControllerTest
    {
        protected IProduct _product;
        protected ProductController _productController;

        public ProductControllerTest()
        {
            var serviceProvider = new ServiceCollection()
                                        .AddLogging()
                                        .BuildServiceProvider();

            var factory = serviceProvider.GetService<IProduct>();
            _productController = new ProductController(factory);

        }

        [Fact]
        public async Task Get_Should_Return_Null_When_Null_RequestModel()
        {
            var taskData = await _productController.Post(null);


            Assert.Null(taskData.Value);

        }
    }
}
