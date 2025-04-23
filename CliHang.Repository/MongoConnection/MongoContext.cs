using CliHang.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CliHang.Repository;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(IOptions<MongoDbSettings> settings, IMongoClient client)
    {
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }
    
    public IMongoCollection<Job> Job => _database.GetCollection<Job>("jobGraph");
}