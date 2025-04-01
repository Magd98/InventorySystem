using Microsoft.OpenApi.Models;
using Play.Catalog.Service.Controllers; // Ensure this namespace matches your project

var builder = WebApplication.CreateBuilder(args);

// Add services for Controllers
builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catalog Service API",
        Version = "v1",
        Description = "An API for managing game catalog items"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog Service API V1");
    c.RoutePrefix = string.Empty; // Makes Swagger UI available at root URL
});

app.UseHttpsRedirection();
app.MapControllers(); // Maps all controller endpoints
app.Run();