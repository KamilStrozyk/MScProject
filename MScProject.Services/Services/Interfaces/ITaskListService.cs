using System.Collections.Generic;
using MongoDB.Bson;

namespace MScProject.Services.Services.Interfaces
{
    public interface ITaskListService
    {
        IEnumerable<BsonDocument> GetAllTaskLists();
        BsonDocument Get(long id);
        IEnumerable<BsonDocument> GetTasks(long id);
        void Create(BsonDocument taskList);
        void Update(BsonDocument taskList);
        void Delete(long id);
    }
}