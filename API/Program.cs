using eShopping.API.Application.Features.DTOs;
using eShopping.API.Application.Features.Interfaces;
using eShopping.API.Application.Features.Products.Commands.Handlers;
using eShopping.API.Infrastructure.Persistence.DbContext;
using eShopping.API.Infrastructure.Persistence.Services;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register the ProductService and IProductService
builder.Services.AddTransient<IProductService, ProductService>();

// Registering the Postgresql
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DevConnection"));
});

// Register MediatR for handling commands and queries
builder.Services.AddMediatR(typeof(AddProductHandler).Assembly); // Automatically register handlers for all commands in the assembly

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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