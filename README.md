# Workshop


## Frontend with Angular
```
$ng new web
$cd web
$ng serve
```

## Backend with .NET C#
* Web API
* Entity Framework with SQLite
* Testing with xUnit

```
$dotnet new webapi -o api
$cd api
$dotnet add package Microsoft.EntityFrameworkCore.Sqlite
$dotnet add package Microsoft.EntityFrameworkCore.Design
$dotnet add package Microsoft.EntityFrameworkCore.Tools
$dotnet add package xunit
$dotnet add package xunit.runner.visualstudio
$dotnet add package Microsoft.NET.Test.Sdk
```

## Working with Docker Compose

Build and run API
```
$docker-compose build api
$docker-compose up api
$docker-compose ps
``` 

Access API at http://localhost:5001/api/products

Build and run Web
```
$docker-compose build web
$docker-compose up web
$docker-compose ps
``` 
Access Web at http://localhost:4200
