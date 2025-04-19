using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CliHang.Repository;

public class BaseRepository
{
    //private readonly IMongoCollection<MinhaEntidade> _colecao;

    public BaseRepository(IOptions<MongoDbSettings> config, IMongoClient client)
    {
        var db = client.GetDatabase(config.Value.DatabaseName);
        // _colecao = db.GetCollection<MinhaEntidade>("minha_colecao");
    }

    // Métodos para buscar, inserir, etc.
}