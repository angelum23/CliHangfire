using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CliHang.Domain;

public class Job
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public string Arguments { get; set; }
    public DateTime CreatedAt { get; set; }
    [BsonSerializer(typeof(IsoDateStringSerializer))]
    public DateTime? ExpireAt { get; set; }
    [BsonSerializer(typeof(IsoDateStringSerializer))]
    public DateTime? FetchedAt { get; set; }
    public Dictionary<string, object> Fields { get; set; }
    public string InvocationData { get; set; }
    public string Key { get; set; }
    public Dictionary<string, object> Parameters { get; set; }
    public string Queue { get; set; }
    public double Score { get; set; }
    public string SetType { get; set; }
    public List<object> StateHistory { get; set; }
    public string StateName { get; set; }
    public string Value { get; set; }
    [BsonRepresentation(BsonType.Array)]
    public List<string> _t { get; set; }
}