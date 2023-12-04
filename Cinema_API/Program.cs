using BusinessLogic.Interfaces;
using BusinessLogic.MovieServices;
using DateAccess;
using DateAccess.Data;
using DateAccess.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//формуємо рядок підключення
string connection = builder.Configuration.GetConnectionString("CinemaConnection") ?? throw new InvalidOperationException("Connection string 'WebAppLibraryContext' not found.");
//string connection = builder.Configuration.GetConnectionString("AzureConnection") ?? throw new InvalidOperationException("Connection string 'WebAppLibraryContext' not found.");


//підключення бази даних через рядок підключення
builder.Services.AddDbContext<CinemaDbContext>(options =>
{ 
          options.UseSqlServer(connection);
          options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGanreService, GanreService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//додаємо Репозиторій
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddSwaggerGen(options =>
{
    options.MapType<TimeSpan>(() => new OpenApiSchema
    {
        Type = "string",
        Example = new OpenApiString("00:00:00")
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
