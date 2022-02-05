using System.Collections.Generic;
using System.Linq;
using MScProject.Database.Models;
using MScProject.Database.Repositories.Interfaces;

namespace MScProject.Database.Repositories
{
    public class TaskListRepository : GenericRepository<TaskList>, ITaskListRepository
    {
        private readonly ApplicationDbContext _context;

        public IEnumerable<Task> GetTasks(long id)
            => _context.Set<Task>().Where(x => x.ListId == id);

        public TaskListRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}