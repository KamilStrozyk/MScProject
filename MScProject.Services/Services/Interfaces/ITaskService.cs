using System.Collections.Generic;
using MScProject.Services.DTO;

namespace MScProject.Services.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskDTO> GetAllTasks();
        TaskDTO Get(long id);
        IEnumerable<PhotoDTO> GetTasksPhotos(long id);
        void Create(TaskDTO task);
        void Update(TaskDTO task);
        void Delete(long id);
    }
}