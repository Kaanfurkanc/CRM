global using Core.ServiceInterfaces;
using Host.ConfigOfInjections;
using Host.Middlewares.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApiVersioning(_ =>
{
    // Default Version 
    _.DefaultApiVersion = new ApiVersion(1, 0);
    _.AssumeDefaultVersionWhenUnspecified = true;
    _.ReportApiVersions = true;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB connection in appsettings
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnectionString"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(DataContext)).GetName().Name);
    });
});

//Service Injections
builder.Services.AddMyDependencyGroup();
// builder pattern 
var app = builder.Build();

// Configure the HTTP request pipeline.
// Middlewares 
// Calling Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

// Generic error handling 
app.UseErrorHandling();

app.UseHttpsRedirection();

app.UseAuthorization();

//UnitOfWork MiddleWare
app.UseUnitOfWork();

app.MapControllers();

app.Run();
