using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Northwind;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//³z¹LDependency Injection ³]©w DbContext
builder.Services.AddControllers();
builder.Services.AddDbContext<Repository.Northwind.NorthwindContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind"))
        );

//Add repository dependecy injection service
builder.Services.AddTransient<Repository.Northwind.INorthwindContext, Repository.Northwind.NorthwindContext>();
builder.Services.AddTransient<Repository.Northwind.INorthwindUnitOfWork, NorthwindUnitOfWork>();

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
