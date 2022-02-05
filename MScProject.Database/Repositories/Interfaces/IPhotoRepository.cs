using System.Collections.Generic;
using MScProject.Database.Models;

namespace MScProject.Database.Repositories.Interfaces
{
    public interface IPhotoRepository: IGenericRepository<Photo>
    {
        IEnumerable<Task> GetTasks(long id);
    }
}