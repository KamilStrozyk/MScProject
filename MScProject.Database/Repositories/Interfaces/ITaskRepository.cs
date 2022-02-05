using System.Collections.Generic;
using MScProject.Database.Models;

namespace MScProject.Database.Repositories.Interfaces
{
    public interface ITaskRepository: IGenericRepository<Task>
    {
        IEnumerable<Photo> GetPhotos(long id);
        void Unassign(long id, long photoId);
        void Assign(long id, long photoId);
    }
}