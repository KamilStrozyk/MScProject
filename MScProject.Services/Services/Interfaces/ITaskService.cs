using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MScProject.Services.Services.Interfaces
{
    public interface ITaskService
    {
        Task<string> GetAllTasks();
        Task<string> Get(string id);
        Task<string> GetTasksPhotos(string id);
        Task Create(string taskJson);
        Task Update(string taskJson);
        Task Delete(string id);
    }
}