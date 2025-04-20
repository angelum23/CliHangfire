using CliHang.Domain;
using MongoDB.Bson;

namespace CliHang.Repository;

public interface IRepJobsGraph
{
    Task<JobsGraph> GetByIdAsync(ObjectId id);
    Task<List<JobsGraph>> GetFailedAsync();
    Task AddAsync(JobsGraph jobsGraph);
    Task RemoveAsync(JobsGraph jobsGraph);
    Task RemoveAsync(ObjectId id);
}