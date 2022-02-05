using System.Collections.Generic;
using MScProject.Database.Models;
using MScProject.Database.Repositories.Interfaces;
using System.Linq;

namespace MScProject.Database.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        private readonly ApplicationDbContext _context;


        public TaskRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Photo> GetPhotos(long id)
        {
            var photoIds = _context.Set<TaskPhoto>().Where(x => x.TaskId == id).Select(x => x.PhotoId);
            return _context.Set<Photo>().Where(x => photoIds.Contains(x.Id));
        }

        public void Unassign(long id, long photoId)
        {
            _context.Remove(new TaskPhoto
            {
                TaskId = id,
                PhotoId = photoId
            });
            _context.SaveChanges();
        }

        public void Assign(long id, long photoId)
        {
            _context.Add(new TaskPhoto
            {
                TaskId = id,
                PhotoId = photoId
            });
            _context.SaveChanges();
        }
    }
}