using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace api.Tests;

public class ProductsApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductsApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProducts_ReturnsSuccess_WithDefaultPagination()
    {
        var response = await _client.GetAsync("/api/products");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<ProductsResponse>();
        Assert.NotNull(body);
        Assert.Equal(10, body.Products.Count);
        Assert.Equal(100, body.Total);
        Assert.Equal(1, body.Page);
        Assert.Equal(10, body.Limit);
    }

    [Fact]
    public async Task GetProducts_ReturnsCorrectPage_WithCustomPagination()
    {
        var response = await _client.GetAsync("/api/products?page=2&limit=5");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<ProductsResponse>();
        Assert.NotNull(body);
        Assert.Equal(5, body.Products.Count);
        Assert.Equal(2, body.Page);
        Assert.Equal(5, body.Limit);
        Assert.Equal(6, body.Products[0].Id);
    }

    [Fact]
    public async Task GetProducts_ReturnsLastPage_WithPartialResults()
    {
        var response = await _client.GetAsync("/api/products?page=4&limit=30");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<ProductsResponse>();
        Assert.NotNull(body);
        Assert.Equal(10, body.Products.Count);
        Assert.Equal(100, body.Total);
    }

    [Fact]
    public async Task GetProducts_ReturnsNotFound_WhenPageExceedsTotal()
    {
        var response = await _client.GetAsync("/api/products?page=999&limit=10");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<ErrorResponse>();
        Assert.NotNull(body);
        Assert.Equal("No products found", body.Error);
    }

    [Fact]
    public async Task GetProducts_ReturnsBadRequest_WhenPageIsInvalid()
    {
        var response = await _client.GetAsync("/api/products?page=0&limit=10");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<ErrorResponse>();
        Assert.NotNull(body);
        Assert.Equal("Page and limit must be positive integers", body.Error);
    }

    [Fact]
    public async Task GetProducts_ReturnsBadRequest_WhenLimitIsInvalid()
    {
        var response = await _client.GetAsync("/api/products?page=1&limit=-1");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<ErrorResponse>();
        Assert.NotNull(body);
        Assert.Equal("Page and limit must be positive integers", body.Error);
    }

    [Fact]
    public async Task GetProducts_ReturnsAllFields_ForEachProduct()
    {
        var response = await _client.GetAsync("/api/products?page=1&limit=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<ProductsResponse>();
        Assert.NotNull(body);

        var product = body.Products[0];
        Assert.Equal(1, product.Id);
        Assert.Equal("Product 1", product.Name);
        Assert.True(product.Price > 0);
        Assert.StartsWith("https://", product.Image);
    }
}

public record ProductsResponse(
    List<ProductDto> Products,
    int Total,
    int Page,
    int Limit
);

public record ProductDto(int Id, string Name, double Price, string Image);

public record ErrorResponse(string Error);
