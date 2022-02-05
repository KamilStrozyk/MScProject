using System.Collections.Generic;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class TaskListService : ITaskListService
    {
        public IEnumerable<TaskListDTO> GetAllTaskLists()
        {
            throw new System.NotImplementedException();
        }

        public TaskListDTO Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TaskDTO> GetTasks(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(TaskListDTO taskList)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TaskListDTO taskList)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}