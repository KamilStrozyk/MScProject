using System.Collections.Generic;
using MScProject.Database.Models;

namespace MScProject.Database.Repositories.Interfaces
{
    public interface ITaskListRepository: IGenericRepository<TaskList>
    {
        IEnumerable<Task> GetTasks(long id);
    }
}