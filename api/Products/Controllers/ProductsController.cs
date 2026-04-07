using api.Products.Services;

namespace api.Products.Controllers;

public static class ProductsController
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/api/products", (int? page, int? limit, IProductService service) =>
        {
            try
            {
                return service.GetProducts(page, limit);
            }
            catch (Exception)
            {
                return Results.Json(new { error = "Internal server error" }, statusCode: 500);
            }
        });
    }
}
