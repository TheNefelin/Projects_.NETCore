using ClassLibrary.Auth.Interfaces;
using ClassLibrary.Auth.Services;
using ClassLibrary.F1Dapper.Interfaces;
using ClassLibrary.F1Dapper.Services;
using ClassLibrary.GamesGuideDapper.Entities;
using ClassLibrary.GamesGuideDapper.Interfaces;
using ClassLibrary.GamesGuideDapper.Services;
using ClassLibrary.PasswordManager.Interfaces;
using ClassLibrary.PasswordManager.Services;
using ClassLibrary.PortfolioDapper.Interfaces;
using ClassLibrary.PortfolioDapper.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DataBase Connection -----------------------------------------------
//builder.Services.AddDbContext<GamesGuideDbContext>(options => // EntityFramework Connection
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerWeb"));
//});

builder.Services.AddTransient<IDbConnection>(options => // Generic Connection
    new SqlConnection(builder.Configuration.GetConnectionString("SqlServerWeb"))
);

builder.Services.AddScoped<SqlConnection>(options => // SqlServer Connection
    new SqlConnection(builder.Configuration.GetConnectionString("SqlServerWeb"))
);
// -------------------------------------------------------------------

// Dependency injection ----------------------------------------------
builder.Services.AddScoped<ApiKeyFilter>();
builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthGoogleService, AuthGoogleService>();

builder.Services.AddTransient<IServiceCRUD<GameEntity>, GameDapperService>();
builder.Services.AddTransient<IServiceCRUD<CharacterEntity>, CharacterDapperService>();
builder.Services.AddTransient<IServiceCRUD<SourceEntity>, SourceDapperService>();
builder.Services.AddTransient<IServiceCRUD<BackgroundEntity>, BackgroundDapperService>();
builder.Services.AddTransient<IServiceCRUD<GuideEntity>, GuideDapperService>();
builder.Services.AddTransient<IServiceCRUD<AdventureEntity>, AdventureDapperService>();
builder.Services.AddTransient<IServiceCRUD<AdventureImgEntity>, AdventureImgDapperService>();
builder.Services.AddTransient<IServiceUserCRUD<GuideUserEntity>, GuideUserDapperService>();
builder.Services.AddTransient<IServiceUserCRUD<AdventureUserEntity>, AdventureUserDapperService>();
builder.Services.AddTransient<IGameGuideDapperService, GameGuideDapperService>();

builder.Services.AddTransient<IPortfolioService, PortfolioService>();

builder.Services.AddTransient<IF1Service, F1Service>();

builder.Services.AddTransient<ICoreService, CoreService>();
// -------------------------------------------------------------------

// JWT Service -------------------------------------------------------
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtOptions =>
    {
        JwtOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
        };
    });
// -------------------------------------------------------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// swagger as Default ------------------------------------------------
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});
// -------------------------------------------------------------------

// Cors --------------------------------------------------------------
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowCredentials();
    options.SetIsOriginAllowed(origin => true);
});
// -------------------------------------------------------------------

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
