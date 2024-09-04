using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TodoApi.Tests
{
    public class TodoApiTests : IClassFixture<WebApplicationFactory<TodoApi.Program>>
    {
        private readonly WebApplicationFactory<TodoApi.Program> _factory;

        public TodoApiTests(WebApplicationFactory<TodoApi.Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/todoitems");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
