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

# HTTP Request API Key Header Filter
* Service
```
public class ApiKeyService : IApiKeyService
{
    private readonly IDbConnection _dapper;

    public ApiKeyService(IDbConnection dapper)
    {
        _dapper = dapper;
    }

    public async Task<bool> ValidateApiKey(string apiKey)
    {
        try
        {
            var sqlApiKey = await _dapper.QueryFirstOrDefaultAsync<string>(
                $"SELECT ApiKey FROM Mae_Config WHERE Id = @Id",
                new { Id = 1 });

            if (sqlApiKey == null) return false;

            return apiKey.Equals(sqlApiKey) ? true : false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
```
* Filter
```
public class AuthApiKeyFilter : IAsyncActionFilter
{
    private readonly string ApiKeyHeaderName = "ApiKey";
    private readonly IApiKeyService _apiKeyService;

    public AuthApiKeyFilter(IApiKeyService apiKeyService)
    {
        _apiKeyService = apiKeyService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey) || string.IsNullOrEmpty(apiKey))
        {
            // Si ApiKey no está presente o es nula, retornar un 401
            context.Result = new UnauthorizedObjectResult(new ResponseApi<object> { 
                IsSucces = false,
                StatusCode = 401,
                Message = "ApiKey es Requerida."
            });

            return;
        }

        var IsValid = await _apiKeyService.ValidateApiKey(apiKey);

        if (!IsValid)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseApi<object>
            { 
                IsSucces = false,
                StatusCode = 401, 
                Message = "ApiKey no Autorizado." 
            });

            return;
        }

        await next();
    }
}
```
* Implementation in Controller
```
[Route("api/public")]
[ApiController]
[ServiceFilter(typeof(AuthApiKeyFilter))]

public class PublicController : ControllerBase
{
    private readonly ILogger<PublicController> _logger;
    public readonly IPublicDapperService _dapper;

    public PublicController(ILogger<PublicController> logger, IPublicDapperService dapper)
    {
        _logger = logger;
        _dapper = dapper;
    }

    [HttpGet("dapper-games")]
    public async Task<ActionResult<ResponseApi<IEnumerable<DataGameDTO>>>> GetAllDapper(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Received request to fetch all games.");
        var result = await _dapper.GetAllAsync("", cancellationToken);

        return StatusCode(result.StatusCode, result);
    }
}
```
