using CliHang.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CliHang.Repository;

public class RepJobsGraph : IRepJobsGraph
{
    private MongoContext _mongoContext { get; set; }
    private IMongoCollection<JobsGraph> _jobsGraph { get; }

    public RepJobsGraph(MongoContext mongoContext)
    {
        _mongoContext = mongoContext;
        _jobsGraph = _mongoContext.JobsGraph;
    }
    
    public async Task<JobsGraph> GetByIdAsync(string id)
    {
        var objectId = new ObjectId(id);
        return await GetByIdAsync(objectId);
    }
    public async Task<JobsGraph> GetByIdAsync(ObjectId id)
    {
        return await _jobsGraph.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<JobsGraph>> GetFailedAsync()
    {
        return await _jobsGraph.Find(x => x.StateName == "Failed").ToListAsync();
    } 
    
    public async Task AddAsync(JobsGraph jobsGraph)
    {
        await _jobsGraph.InsertOneAsync(jobsGraph);
    }
    
    public async Task RemoveAsync(JobsGraph jobsGraph)
    {
        RemoveAsync(jobsGraph.Id);
    }
    public async Task RemoveAsync(ObjectId id)
    {
        await _jobsGraph.DeleteOneAsync(x => x.Id == id);
    }}