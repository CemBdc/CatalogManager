using CatalogManager.IntegrationTest.Fixtures;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CatalogManager.IntegrationTest.Scenarios
{
    
    public class PingTests
    {
        private readonly TestContext _sut;

        public PingTests()
        {
            _sut = new TestContext();
        }

        [Fact]
        public async Task PingReturnsOkResponse()
        {
            var response = await _sut.Client.GetAsync("/api/v1/product/HealthCheck");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
