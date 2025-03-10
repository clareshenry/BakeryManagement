# Final Project - Henry Clares

## BakeryManagement

Dotnet version `8.0.101`

## Create Database

```bash
POSTGRES_PASSWORD = postgres
POSTGRES_USER = postgres
POSTGRES_DB = bakery_db
```

## Configuration

You can change the connection string with your own credentials.

```c#
optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=bakery_db;Username=postgres;Password=postgres"
            );
```

```bash
nano BakeryManagement/BakeryManagement.Infrastructure/Database/AppDbContext.cs
```

## Setup Project

```bash
dotnet ef database update --project BakeryManagement.Infrastructure
```

## Run Project

```bash
dotnet run --project BakeryManagement.Presentation
```
