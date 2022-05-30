using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MScProject.Database.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Create(T obj);
        Task Update(T obj, ObjectId id);
        Task Delete(string id);
    }
}