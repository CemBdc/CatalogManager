using CatalogManager.Dto;
using CatalogManager.IntegrationTest.Fixtures;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CatalogManager.IntegrationTest.Scenarios
{
    public class ProductControllerTests
    {
        private readonly TestContext _sut;

        public ProductControllerTests()
        {
            _sut = new TestContext();
        }

        [Fact]
        public async Task Post_Should_Return_OK_When_Insert_Success()
        {
            var expectedStatusCode = HttpStatusCode.OK;

            // Arrange
            var request = new AddProductDto
            {
                Code = "TesctCode123",
                Name = "TestName",
                Picture = "http://test.com",
                Price = 123
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _sut.Client.PostAsync("/api/v1/product", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async Task Post_Should_Return_BadRequest_When_Send_Empty_Code()
        {
            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Arrange
            var request = new AddProductDto
            {
                Code = "",
                Name = "TestName",
                Picture = "http://test.com",
                Price = 123
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _sut.Client.PostAsync("/api/v1/product", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async Task Post_Should_Return_BadRequest_When_Price_Is_Out_Of_Range()
        {
            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Arrange
            var request = new AddProductDto
            {
                Code = "TesctCode123",
                Name = "TestName",
                Picture = "http://test.com",
                Price = 1000
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _sut.Client.PostAsync("/api/v1/product", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async Task Post_Should_Return_OK_When_Insert_Success_And_Get_Product_By_Code()
        {
            var postExpectedStatusCode = HttpStatusCode.OK;
            var getExpectedStatusCode = HttpStatusCode.OK;

            // Arrange
            var request = new AddProductDto
            {
                Code = "TesctCode123",
                Name = "TestName",
                Picture = "http://test.com",
                Price = 123
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _sut.Client.PostAsync("/api/v1/product", content);

            var actualPostStatusCode = response.StatusCode;
            string actualPostResult = await response.Content.ReadAsStringAsync();
            AddProductDto actualPostResultDataObject = JsonConvert.DeserializeObject<AddProductDto>(actualPostResult);

            // Act
            var response2 = await _sut.Client.GetAsync("/api/v1/product/" + actualPostResultDataObject.Code);

            var actualGetStatusCode = response2.StatusCode;
            string actualGetResult = await response2.Content.ReadAsStringAsync();
            AddProductDto actualGetResultDataObject = JsonConvert.DeserializeObject<AddProductDto>(actualGetResult);


            // Assert
            Assert.Equal(postExpectedStatusCode, actualPostStatusCode);
            Assert.Equal(getExpectedStatusCode, actualGetStatusCode);

            Assert.NotNull(actualGetResultDataObject);
            Assert.Equal(actualPostResultDataObject.Code, actualGetResultDataObject.Code);
            
        }
    }
}
