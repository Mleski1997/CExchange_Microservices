// Infrastructure/DAL/MongoDB/Serialization/EmailSerializer.cs
using CExchange.Services.Users.Core.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

public class EmailSerializer : SerializerBase<Email>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Email value)
    {
        context.Writer.WriteString(value.Value);
    }

    public override Email Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        switch (context.Reader.CurrentBsonType)
        {
            case BsonType.String:
                var stringValue = context.Reader.ReadString();
                return new Email(stringValue);
            case BsonType.Document:
                context.Reader.ReadStartDocument();
                var documentValue = context.Reader.ReadString("value");
                context.Reader.ReadEndDocument();
                return new Email(documentValue);
            default:
                throw new BsonSerializationException($"Cannot deserialize Email from BsonType {context.Reader.CurrentBsonType}. Expected BsonType.String or BsonType.Document.");
        }
    }
}
