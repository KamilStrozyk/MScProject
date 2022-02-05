using System.Collections.Generic;
using MScProject.Database.Models;

namespace MScProject.Database.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T: EntityBase
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T toAdd);
        void Update(T toUpdate);
        void Delete(long id);
    }
}