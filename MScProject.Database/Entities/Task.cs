using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MScProject.Database.Entities
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<ObjectId> Photos { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}