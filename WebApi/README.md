# Projects WebApi .NET 7

## Dependencies
```
ClassLibrary.GamesGuide
```

# DataBase Connection
* appsetings.json
```
"ConnectionStrings": {
    "SqlServerWeb": "Data Source=localhost; Initial Catalog=db_testing; User ID=testing; Password=testing; TrustServerCertificate=True;",
    "SqlServer": "Server=localhost; Database=db_testing; User ID=testing; Password=testing; TrustServerCertificate=True;"
}
```
* Program.cs
```
builder.Services.AddDbContext<GamesGuideDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerWeb"));
})
```

# Swagger for Production
```
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});
```

# Migracion
* Consola Admin Paquetes: Herramientas -> Admin Paquetes NuGet -> Consola Admin Paquetes NuGet
```
Add-Migration Inicial
update-database
```