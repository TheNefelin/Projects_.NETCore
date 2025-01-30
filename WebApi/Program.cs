using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuide.Connection;
using ClassLibrary.GamesGuide.Interfaces;
using ClassLibrary.GamesGuide.Services;
using ClassLibrary.GamesGuideDapper.Interfaces;
using ClassLibrary.GamesGuideDapper.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DataBase Connection -----------------------------------------------
builder.Services.AddDbContext<GamesGuideDbContext>(options => // EntityFramework
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerWeb"));
});

builder.Services.AddTransient<IDbConnection>(options => // Dapper
    new SqlConnection(builder.Configuration.GetConnectionString("SqlServerWeb"))
);
// -------------------------------------------------------------------

// Dependency injection ----------------------------------------------
builder.Services.AddTransient<IPublicService, PublicEFService>();
builder.Services.AddTransient<IGamesService, GameEFService>();

builder.Services.AddTransient<IServiceCRUD<GameDTO>, GameDapperService>();
builder.Services.AddTransient<IServiceCRUD<CharacterDTO>, CharacterDapperService>();
builder.Services.AddTransient<IServiceCRUD<SourceDTO>, SourceDapperService>();
builder.Services.AddTransient<IServiceCRUD<BackgroundDTO>, BackgroundDapperService>();
builder.Services.AddTransient<IServiceCRUD<GuideDTO>, GuideDapperService>();
builder.Services.AddTransient<IServiceCRUD<AdventureDTO>, AdventureDapperService>();
builder.Services.AddTransient<IServiceCRUD<AdventureImgDTO>, AdventureImgDapperService>();
builder.Services.AddTransient<IServiceUserCRUD<GuideUserDTO>, GuideUserDapperService>();
builder.Services.AddTransient<IServiceUserCRUD<AdventureUserDTO>, AdventureUserDapperService>();
builder.Services.AddTransient<PublicDapperService>();
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
