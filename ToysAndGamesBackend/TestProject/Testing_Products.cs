using API;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Mail;
using Xunit.Abstractions;

namespace TestProject
{
    public class Testing_Products
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public Testing_Products(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _webApplicationFactory = new WebApplicationFactory<Program>();
        }
        [Fact]
        public async void GetProducts()
        {
            //Arrange
            var client = _webApplicationFactory.CreateDefaultClient();
            
            //Act
            var response = await client.GetAsync("/api/products");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(content);
            Assert.False(string.IsNullOrEmpty(content));
        }

        [Fact]
        public async void GetProduct()
        {
            //Arrange
            var client = _webApplicationFactory.CreateDefaultClient();
            int productId = 1;

            //Act
            var response = await client.GetAsync($"/api/product/{productId}");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(content);
            Assert.False(string.IsNullOrEmpty(content));
        }
    }
}