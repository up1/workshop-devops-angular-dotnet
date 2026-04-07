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

Build and run [SQL Server](https://learn.microsoft.com/th-th/azure/data-api-builder/deployment/local-container)
```
$docker-compose build mssql
$docker-compose up mssql
$docker-compose ps
```

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


## Working with API Gateway
* [Kong](https://developer.konghq.com/gateway/install/)
* [Docker kong](https://github.com/Kong/docker-kong)


Install Kong Gateway with Docker Compose
* PostgreSQL database for Kong
```
$git clone https://github.com/Kong/docker-kong
$cd docker-kong/compose/
$export KONG_DATABASE=postgres
$docker compose --profile database up -d

$docker compose ps
```
Waiting for services to be healthy

### Gateway API's urls :
* http://localhost:8000 - send traffic to your service via Kong
* http://localhost:8001 - configure Kong using Admin API or via [decK](https://github.com/kong/deck)
* http://localhost:8002 - access Kong's management [Web UI (Kong Manager)](https://github.com/Kong/kong-manager)

List of plugins in Kong manager
* http://localhost:8002/plugins/select

## Add your service to Kong API Gateway
* Add service
* Add route to service

Add service
* use `host.docker.internal` instead of `localhost` to access service from Kong container
```
$curl http://127.0.0.1:8001/services \
    -d name=demo-api \
    -d url=http://host.docker.internal:5001
```

Add route to service
```
$curl http://127.0.0.1:8001/services/demo-api/routes \
    -d name=demo-api \
	-d 'paths[]=/test'
```

Check call API via Kong
```
$curl http://localhost:8000/test/api/products
``` 
