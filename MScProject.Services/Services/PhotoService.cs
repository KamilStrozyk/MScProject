using System.Collections.Generic;
using MongoDB.Bson;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class PhotoService: IPhotoService
    {
        public IEnumerable<BsonDocument> GetAllPhotos()
        {
            throw new System.NotImplementedException();
        }

        public BsonDocument Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BsonDocument> GetTasks(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(BsonDocument photo)
        {
            throw new System.NotImplementedException();
        }

        public void Update(BsonDocument photo)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}