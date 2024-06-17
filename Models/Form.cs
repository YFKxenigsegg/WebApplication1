using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models;
public class Form
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = default!;
    public IEnumerable<Field> Fields { get; set; } = Enumerable.Empty<Field>();
}

public class Field
{
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public bool IsRequired { get; set; }
}
