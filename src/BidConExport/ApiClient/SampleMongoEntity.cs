using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ApiClient;
public class SampleMongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string MyProperty { get; set; } = string.Empty;
}
