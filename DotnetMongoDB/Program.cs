using DotnetMongoDB.Services;
using MongoDB.Driver;
using System.Security.Authentication;
using System.Xml.Xsl;

var builder = WebApplication.CreateBuilder(args);
//.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var config = builder.Configuration;

builder.Services.AddSingleton<IConfiguration>(config);

MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(config["CosmosDb:ConnectionString"]));
settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

builder.Services.AddSingleton((s) => new MongoClient(settings));
builder.Services.AddTransient<IBookService, BookService>();

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
