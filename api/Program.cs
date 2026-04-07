var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

var products = Enumerable.Range(1, 100).Select(i => new Product(
    i,
    $"Product {i}",
    Math.Round(9.99 + i * 1.5, 2),
    $"https://picsum.photos/seed/product{i}/200/200"
)).ToList();

app.MapGet("/api/products", (int? page, int? limit) =>
{
    try
    {
        var pageValue = page ?? 1;
        var limitValue = limit ?? 10;

        if (pageValue < 1 || limitValue < 1)
        {
            return Results.BadRequest(new { error = "Page and limit must be positive integers" });
        }

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
    catch (Exception)
    {
        return Results.Json(new { error = "Internal server error" }, statusCode: 500);
    }
});

app.Run();

public record Product(int Id, string Name, double Price, string Image);

public partial class Program { }
