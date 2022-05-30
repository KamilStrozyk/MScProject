using System.Collections.Generic;
using MongoDB.Bson;

namespace MScProject.Services.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<BsonDocument> GetAllTasks();
        BsonDocument Get(long id);
        IEnumerable<BsonDocument> GetTasksPhotos(long id);
        void Create(BsonDocument task);
        void Update(BsonDocument task);
        void Delete(long id);
    }
}