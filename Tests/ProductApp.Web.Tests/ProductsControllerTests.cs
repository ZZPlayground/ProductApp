using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Interfaces;
using ProductApp.Domain;
using ProductApp.Web.Controllers;
using Microsoft.Extensions.Logging;

namespace ProductApp.Web.Tests;

public class ProductsControllerTests
{
    private readonly Mock<IProductService> _mockService;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        _mockService = new Mock<IProductService>();
        _controller = new ProductsController(Mock.Of<ILogger<ProductsController>>(), _mockService.Object);
    }

    [Fact]
    public async Task Index_ReturnsAViewResult_WithAListOfProducts()
    {
        // Arrange
        _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(new List<Product>());

        // Act
        var result = await _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);
    }

    [Fact]
    public async Task Create_ShouldRedirectToIndex_WhenProductIsValid()
    {
        // Arrange
        var product = new Product
        {
            Name = "Test Product",
            Description = "Test Description",
            Price = 10.00m,
            Quantity = 100
        };

        // Act
        var result = await _controller.Create(product);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        _mockService.Verify(service => service.AddAsync(It.IsAny<Product>()), Times.Once);
    }
}
