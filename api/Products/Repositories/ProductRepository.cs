using api.Data;
using api.Products.Models;

namespace api.Products.Repositories;

public interface IProductRepository
{
    List<Product> GetAll();
}

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll() => _context.Products.OrderBy(p => p.Id).ToList();
}
