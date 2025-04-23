using CliHang.Domain;
using MongoDB.Bson;

namespace CliHang.Repository;

public interface IRepJob
{
    Task<Job> GetByIdAsync(ObjectId id);
    Task<List<Job>> GetFailedAsync();
    Task AddAsync(Job job);
    Task RemoveAsync(Job job);
    Task RemoveAsync(ObjectId id);
}