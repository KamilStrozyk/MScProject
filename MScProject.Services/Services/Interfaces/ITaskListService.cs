using System.Collections.Generic;
using System.Threading.Tasks;
using MScProject.Services.DTO;

namespace MScProject.Services.Services.Interfaces
{
    public interface ITaskListService
    {
        Task<IEnumerable<TaskListDTO>> GetAllTaskLists();
        Task<TaskListDTO> Get(string id);
        Task<IEnumerable<TaskDTO>> GetTasks(string id);
        Task Create(TaskListDTO taskList);
        Task Update(TaskListDTO taskList);
        Task Delete(string id);
    }
}