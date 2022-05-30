using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MScProject.Database.Entities
{
    public class Photo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public byte[] Content { get; set; } 
    }
}