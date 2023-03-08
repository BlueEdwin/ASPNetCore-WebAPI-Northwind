using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Repository.Northwind;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Northwind API",
        Description = "An ASP.NET Core Web API for managing Northwind Database Datas",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

//³z¹LDependency Injection ³]©w DbContext
builder.Services.AddControllers();
builder.Services.AddDbContext<Repository.Northwind.NorthwindContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind"))
        );

//Add repository layer dependecy injection service
builder.Services.AddTransient<Repository.Northwind.INorthwindContext, Repository.Northwind.NorthwindContext>();
builder.Services.AddTransient<Repository.Northwind.INorthwindUnitOfWork, NorthwindUnitOfWork>();

builder.Services.AddAutoMapper(System.AppDomain.CurrentDomain.GetAssemblies());

//Add service layer dependecy injection service
builder.Services.AddScoped<Service.Northwind.INorthwindService, Service.Northwind.NorthwindService>();

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
