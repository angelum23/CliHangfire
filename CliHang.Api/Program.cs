using CliHang.Controller;
using CliHang.Domain.Interface;
using CliHang.Repository;
using CliHang.Service;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);
});

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddScoped<JobController>();
builder.Services.AddScoped<MongoContext>();
builder.Services.AddScoped<IRepJob, RepJob>();
builder.Services.AddScoped<IServJob, ServJob>();


var app = builder.Build();

app.MapControllers();

app.Run();