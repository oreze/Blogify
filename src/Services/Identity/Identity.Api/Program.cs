using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Identity.Domain.AggregationModels.ApplicationUser.ValueObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UsePathBase("/basepath");

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", async () =>
{
    var client = new HttpClient();

    var response = await client.GetAsync("https://api.first.org/data/v1/countries");

    var responseString = await response.Content.ReadAsStringAsync();

    var customObject = JsonSerializer.Deserialize<ExpandoObject>(responseString);
    var node = customObject.Where(v => v.Key == "data");
    var val = (JsonElement)node.Select(x => x.Value).FirstOrDefault();
    var deserialized = JsonSerializer.Deserialize<CountryInfo>(val).ToString();
    
    var x = "KEKW";

});

app.Run();