using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Northwind;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//�z�LDependency Injection �]�w DbContext
builder.Services.AddControllers();
builder.Services.AddDbContext<NorthwindContext>(
            options => options.UseSqlServer("Northwind")
        );

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
