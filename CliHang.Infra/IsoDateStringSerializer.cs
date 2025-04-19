using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using System.Globalization;

public class IsoDateStringSerializer : SerializerBase<DateTime?>
{
    public override DateTime? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var bsonType = context.Reader.GetCurrentBsonType();

        if (bsonType == BsonType.Null)
        {
            context.Reader.ReadNull();
            return null;
        }

        var dateStr = context.Reader.ReadString();
        if (DateTime.TryParse(dateStr, null, DateTimeStyles.RoundtripKind, out var result))
            return result;

        return null;
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime? value)
    {
        if (value == null)
        {
            context.Writer.WriteNull();
        }
        else
        {
            context.Writer.WriteString(value.Value.ToString("o"));
        }
    }
}