using System.Collections.Generic;
using MongoDB.Bson;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class TaskService: ITaskService
    {
        public IEnumerable<BsonDocument> GetAllTasks()
        {
            throw new System.NotImplementedException();
        }

        public BsonDocument Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BsonDocument> GetTasksPhotos(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(BsonDocument task)
        {
            throw new System.NotImplementedException();
        }

        public void Update(BsonDocument task)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}