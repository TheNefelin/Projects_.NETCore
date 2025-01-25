using ClassLibrary.GamesGuide.Connection;
using ClassLibrary.GamesGuide.Interfaces;
using ClassLibrary.GamesGuide.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DataBase Connection -----------------------------------------------
builder.Services.AddDbContext<GamesGuideDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerWeb"));
});
// -------------------------------------------------------------------

// Dependency injection ----------------------------------------------
builder.Services.AddTransient<IPublicService, PublicService>();
builder.Services.AddTransient<IGamesService, GameService>();
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
