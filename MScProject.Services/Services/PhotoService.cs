using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MScProject.Database.Models;
using MScProject.Database.Repositories.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public IEnumerable<PhotoDTO> GetAllPhotos()
            => _photoRepository.GetAll().Select(x => new PhotoDTO()
            {
                Id = x.Id,
                Content = Encoding.ASCII.GetString(x.Content),
            });

        public PhotoDTO Get(long id)
        {
            var model = _photoRepository.Get(id);
            return new PhotoDTO()
            {
                Id = model.Id,
                Content = Encoding.ASCII.GetString(model.Content),
            };
        }

        public IEnumerable<TaskDTO> GetTasks(long id)
            => _photoRepository.GetTasks(id).Select(x => new TaskDTO
            {
                Id = x.Id,
                ListId = x.ListId,
                CreatedAt = x.CreatedAt,
                Description = x.Description,
                Title = x.Title
            });

        public void Create(PhotoDTO photo)
            => _photoRepository.Add(new Photo
            {
                Id = photo.Id,
                Content = Encoding.ASCII.GetBytes(photo.Content)
            });

        public void Update(PhotoDTO photo)
            => _photoRepository.Update(new Photo
            {
                Id = photo.Id,
                Content = Encoding.ASCII.GetBytes(photo.Content)
            });

        public void Delete(long id)
            => _photoRepository.Delete(id);
    }
}