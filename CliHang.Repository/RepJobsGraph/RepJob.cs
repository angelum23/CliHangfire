using CliHang.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CliHang.Repository;

public class RepJob : IRepJob
{
    private MongoContext _mongoContext { get; set; }
    private IMongoCollection<Job> _job { get; }

    public RepJob(MongoContext mongoContext)
    {
        _mongoContext = mongoContext;
        _job = _mongoContext.Job;
    }
    
    public async Task<Job> GetByIdAsync(string id)
    {
        var objectId = new ObjectId(id);
        return await GetByIdAsync(objectId);
    }
    public async Task<Job> GetByIdAsync(ObjectId id)
    {
        return await _job.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Job>> GetFailedAsync()
    {
        return await _job.Find(x => x.StateName == "Failed").ToListAsync();
    } 
    
    public async Task AddAsync(Job job)
    {
        await _job.InsertOneAsync(job);
    }
    
    public async Task RemoveAsync(Job job)
    {
        RemoveAsync(job.Id);
    }
    public async Task RemoveAsync(ObjectId id)
    {
        await _job.DeleteOneAsync(x => x.Id == id);
    }}