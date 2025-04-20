using CliHang.Repository;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddScoped<MongoContext>();
builder.Services.AddScoped<IRepJobsGraph, RepJobsGraph>();

app.Run();