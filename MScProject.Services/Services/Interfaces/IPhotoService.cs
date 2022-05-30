using System.Collections.Generic;
using MongoDB.Bson;

namespace MScProject.Services.Services.Interfaces
{
    public interface IPhotoService
    {
        IEnumerable<BsonDocument> GetAllPhotos();
        BsonDocument Get(long id);
        IEnumerable<BsonDocument> GetTasks(long id);
        void Create(BsonDocument photo);
        void Update(BsonDocument photo);
        void Delete(long id);
    }
}