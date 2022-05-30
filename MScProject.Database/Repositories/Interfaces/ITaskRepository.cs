using System.Collections.Generic;
using System.Threading.Tasks;
using MScProject.Database.Entities;
using DbTask = MScProject.Database.Entities.Task;

namespace MScProject.Database.Repositories.Interfaces
{
    public interface ITaskRepository : IGenericRepository<DbTask>
    {
        Task<IEnumerable<Photo>> GetTasksPhotos(string id);
    }
}