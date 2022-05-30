using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MScProject.Services.Services.Interfaces
{
    public interface ITaskListService
    {
        Task<string> GetAllTaskLists();
        Task<string> Get(string id);
        Task<string> GetTasks(string id);
        Task Create(string taskListJson);
        Task Update(string taskListJson);
        Task Delete(string id);
    }
}