using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MScProject.Services.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<string> GetAllPhotos();
        Task<string> Get(string id);
        Task<string> GetTasks(string id);
        Task Create(string photoJson);
        Task Update(string photoJson);
        Task Delete(string id);
    }
}