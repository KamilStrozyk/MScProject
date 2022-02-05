using System.Collections.Generic;
using System.Linq;
using MScProject.Database.Models;
using MScProject.Database.Repositories.Interfaces;

namespace MScProject.Database.Repositories
{
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        private readonly ApplicationDbContext _context;

        public IEnumerable<Task> GetTasks(long id)
        {
            var taskIds = _context.Set<TaskPhoto>().Where(x => x.PhotoId == id).Select(x => x.TaskId);
            return _context.Set<Task>().Where(x => taskIds.Contains(x.Id));
        }

        public PhotoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}