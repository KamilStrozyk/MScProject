using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MScProject.Database.Entities
{
    public class TaskList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}