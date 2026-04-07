using api.Products.Models;

namespace api.Products.Repositories;

public interface IProductRepository
{
    List<Product> GetAll();
}

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public ProductRepository()
    {
        _products = Enumerable.Range(1, 100).Select(i => new Product(
            i,
            $"Product {i}",
            Math.Round(9.99 + i * 1.5, 2),
            $"https://picsum.photos/seed/product{i}/200/200"
        )).ToList();
    }

    public List<Product> GetAll() => _products;
}
