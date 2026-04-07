using api.Products.Models;
using api.Products.Repositories;

namespace api.Products.Services;

public interface IProductService
{
    IResult GetProducts(int? page, int? limit);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IResult GetProducts(int? page, int? limit)
    {
        var pageValue = page ?? 1;
        var limitValue = limit ?? 10;

        if (pageValue < 1 || limitValue < 1)
        {
            return Results.BadRequest(new { error = "Page and limit must be positive integers" });
        }

        var products = _repository.GetAll();
        var total = products.Count;
        var skip = (pageValue - 1) * limitValue;

        if (skip >= total)
        {
            return Results.NotFound(new { error = "No products found" });
        }

        var pagedProducts = products.Skip(skip).Take(limitValue).ToList();

        return Results.Ok(new
        {
            products = pagedProducts,
            total,
            page = pageValue,
            limit = limitValue
        });
    }
}
