using System.Collections.Generic;
using System.Threading.Tasks;
using MScProject.Services.DTO;

namespace MScProject.Services.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAllTasks();
        Task<TaskDTO> Get(string id);
        Task<IEnumerable<PhotoDTO>> GetTasksPhotos(string id);
        Task Create(TaskDTO task);
        Task Update(TaskDTO task);
        Task Delete(string id);
    }
}