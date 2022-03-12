using Blogging.Configuration;
using Blogify.Configuration;
using Blogify.Domain.Data;
using Blogify.Domain.Entities;
using Blogify.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// configure services by user.
builder.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.MapGraphQL();

app.UseHttpsRedirection();

app.ConfigureDatabase();
app.Run();
