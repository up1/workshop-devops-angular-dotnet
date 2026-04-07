# List of products


## Web
* Use Angular to create a simple web application that displays a list of products
* Working with folder `web`
* In route `/` try to get data from `http://localhost:5001/api/products` and show it in the list
  * use http client
  * add timeout for request (5 seconds)
  * add error handling
  * add loading state
  * Create a component `ProductItem` to show product details (name, price, image)
  * Add pagination (show 10 products per page)


## API
* Use .NET C# to create a simple API that returns a list of products
* Working with folder `api`
* Create a simple API to return list of products
  * Create a route GET `/api/products` that returns a list of products in JSON format
  * Each product should have the following fields: `id`, `name`, `price`, `image`
  * You can use a static list of products or generate them dynamically
  * Add pagination support (accept query parameters `page` and `limit` to return the appropriate subset of products)
  * Add error handling (return appropriate HTTP status codes and error messages)
* Create integration tests for the API using a testing framework like xUnit or NUnit
  * Test the GET `/api/products` endpoint for success and error scenarios
  * Test pagination functionality
  * Test error handling (e.g., when no products are found or when there is an internal server error)

### Project structure with feature-based organization
```
├── api
│   ├── products
│   │   ├── ProductsController.cs
│   │   ├── Product.cs
│   │   ├── ProductService.cs
│   │   └── ProductRepository.cs
│   ├── Startup.cs
│   └── Program.cs
├── web
│   ├── src
│   │   ├── app
│   │   │   ├── components
│   │   │   │   ├── product-item
│   │   │   │   │   ├── product-item.component.ts
│   │   │   │   │   ├── product-item.component.html
│   │   │   │   │   └── product-item.component.css
│   │   │   ├── services
│   │   │   │   └── product.service.ts
│   │   │   ├── app.component.ts
│   │   │   ├── app.component.html
│   │   │   └── app.component.css
│   ├── angular.json
│   ├── package.json
│   └── tsconfig.json
```

### API Specification of GET `/api/products`
* Success with 200
```
{
    "products": [
        {
        "id": 1,
        "name": "Product 1",
        "price": 10.99,
        "image": "https://example.com/product1.jpg"
        },
        {
        "id": 2,
        "name": "Product 2",
        "price": 19.99,
        "image": "https://example.com/product2.jpg"
        },
        ...
    ],
    "total": 100,
    "page": 1,
    "limit": 10         
}
```

* Success with 404
```
{
    "error": "No products found"
}
```
* Success with 500
```
{
    "error": "Internal server error"
}
```