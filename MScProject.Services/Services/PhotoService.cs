using System.Collections.Generic;
using System.Linq;
using System.Text;
using MScProject.Database;
using MScProject.Database.Models;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly ApplicationDbContext _context;

        public PhotoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PhotoDTO> GetAllPhotos()
            => _context.Set<Photo>()
                .Where(x => x != null)
                .Select(x => new PhotoDTO {Id = x.Id, Content = Encoding.ASCII.GetString(x.Content)});

        public PhotoDTO Get(long id)
            => _context.Set<Photo>()
                .Where(x => x.Id == id)
                .Select(x => new PhotoDTO {Id = x.Id, Content = Encoding.ASCII.GetString(x.Content)})
                .SingleOrDefault();

        public IEnumerable<TaskDTO> GetTasks(long id)
        {
            var taskIds = _context.Set<TaskPhoto>().Where(x => x.PhotoId == id).Select(x => x.TaskId).ToArray();

            return _context.Set<Task>().Where(x => taskIds.Contains(x.Id))
                .Select(x => new TaskDTO
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    Title = x.Title,
                    Description = x.Description
                });
        }

        public void Create(PhotoDTO photo)
        {
            _context.Set<Photo>().Add(new Photo
            {
                Id = photo.Id,
                Content = Encoding.ASCII.GetBytes(photo.Content)
            });
            _context.SaveChanges();
        }

        public void Update(PhotoDTO photo)
        {
            _context.Set<Photo>().Update(new Photo
            {
                Id = photo.Id,
                Content = Encoding.ASCII.GetBytes(photo.Content)
            });
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var toRemove = _context.Set<Photo>().SingleOrDefault(x => x.Id == id);
            if (toRemove != null)
            {
                _context.Set<Photo>().Remove(toRemove);
                _context.SaveChanges();
            }
        }
    }
}