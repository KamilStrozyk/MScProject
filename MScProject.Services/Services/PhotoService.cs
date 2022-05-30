using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MScProject.Database.Entities;
using MScProject.Database.Repositories.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace MScProject.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<IEnumerable<PhotoDTO>> GetAllPhotos()
            => (await _photoRepository.GetAll()).Select(photo => new PhotoDTO {Id = photo.Id, Content = photo.Content});

        public async Task<PhotoDTO> Get(string id)
        {
            var result = await _photoRepository.Get(id);
            return new PhotoDTO
            {
                Id = result.Id,
                Content = result.Content
            };
        }

        public async Task<IEnumerable<TaskDTO>> GetTasks(string id)
            => (await _photoRepository.GetTasks(id)).Select(task => new TaskDTO()
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.ToJson()
            });

        public async Task Create(PhotoDTO photo)
        {
            var photoToAdd = new Photo
            {
                Id = photo.Id,
                Content = photo.Content
            };
            await _photoRepository.Create(photoToAdd);
        }

        public async Task Update(PhotoDTO photo)
        {
            var photoToUpdate = new Photo
            {
                Id = photo.Id,
                Content = photo.Content
            };
            await _photoRepository.Update(photoToUpdate, new ObjectId(photo.Id));
        }

        public async Task Delete(string id)
            => await _photoRepository.Delete(id);
    }
}