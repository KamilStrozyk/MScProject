using System.Collections.Generic;
using MScProject.Services.DTO;

namespace MScProject.Services.Services.Interfaces
{
    public interface ITaskListService
    {
        IEnumerable<TaskListDTO> GetAllTaskLists();
        TaskListDTO Get(long id);
        IEnumerable<TaskDTO> GetTasks(long id);
        void Create(TaskListDTO taskList);
        void Update(TaskListDTO taskList);
        void Delete(long id);
    }
}