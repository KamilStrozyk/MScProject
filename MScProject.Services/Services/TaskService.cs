using System.Collections.Generic;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class TaskService: ITaskService
    {
        public IEnumerable<TaskDTO> GetAllTasks()
        {
            throw new System.NotImplementedException();
        }

        public TaskDTO Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PhotoDTO> GetTasksPhotos(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(TaskDTO task)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TaskDTO task)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}