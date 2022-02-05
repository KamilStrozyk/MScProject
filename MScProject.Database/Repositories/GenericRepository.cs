using System.Collections.Generic;
using System.Linq;
using MScProject.Database.Models;
using MScProject.Database.Repositories.Interfaces;

namespace MScProject.Database.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: EntityBase
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
            => _context.Set<T>().Where(x => x.Id != null);

        public T Get(long id)
            => _context.Set<T>().SingleOrDefault(x => x.Id == id);

        public void Add(T toAdd)
        {
            _context.Set<T>().Add(toAdd);
            _context.SaveChanges();
        }

        public void Update(T toUpdate)
        {
            _context.Set<T>().Update(toUpdate);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var toRemove = _context.Set<T>().SingleOrDefault(x => x.Id == id);
            if (toRemove != null) _context.Set<T>().Remove(toRemove);
            _context.SaveChanges();
        }
    }
}