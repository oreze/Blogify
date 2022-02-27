using Blogify.Configuration;
using Blogify.Domain.Data;
using Blogify.Domain.Entities;
using Blogify.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ServicesConfiguration.ConfigureServices(ref builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.MapGraphQL();

app.UseHttpsRedirection();

DatabaseExtensions.ConfigureDatabase(app);
app.Run();
