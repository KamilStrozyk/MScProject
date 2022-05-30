using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Entities;
using MScProject.Database.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using Task = System.Threading.Tasks.Task;
using DbTask = MScProject.Database.Entities.Task;

namespace MScProject.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private const string collectionName = "photo";
        private const string taskCollectionName = "task";
        private readonly IMongoDbContext _context;

        public PhotoService(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhotoDTO>> GetAllPhotos()
        {
            var all = await _context.GetCollection<Photo>(collectionName).FindAsync(Builders<Photo>.Filter.Empty);
            return all.ToList().Select(photo => new PhotoDTO()
            {
                Id = photo.Id,
                Content = photo.Content,
            });
        }

        public async Task<PhotoDTO> Get(string id)
        {
            var objectId = new ObjectId(id);

            var filter = Builders<Photo>.Filter.Eq("_id", objectId);

            var result = await _context.GetCollection<Photo>(collectionName).FindAsync(filter).Result
                .FirstOrDefaultAsync();

            return new PhotoDTO()
            {
                Id = result.Id,
                Content = result.Content,
            };
        }

        public async Task<IEnumerable<TaskDTO>> GetTasks(string id)
        {
            var objectId = new ObjectId(id);
            var taskFilter = Builders<DbTask>.Filter.AnyEq("Photos", objectId);
            var tasks = await _context.GetCollection<DbTask>(taskCollectionName).FindAsync(taskFilter);

            return tasks.ToList().Select(task => new TaskDTO()
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.ToJson()
            });
        }

        public async Task Create(PhotoDTO photo)
        {
            var photoToAdd = new Photo()
            {
                Id = photo.Id,
                Content = photo.Content,
            };

            await _context.GetCollection<Photo>(collectionName).InsertOneAsync(photoToAdd);
        }

        public async Task Update(PhotoDTO photo)
        {
            var photoToUpdate = new Photo()
            {
                Id = photo.Id,
                Content = photo.Content,
            };

            var objectId = new ObjectId(photo.Id);

            await _context.GetCollection<Photo>(collectionName)
                .ReplaceOneAsync(Builders<Photo>.Filter.Eq("_id", objectId), photoToUpdate);
        }

        public async Task Delete(string id)
        {
            var objectId = new ObjectId(id);

            await _context.GetCollection<Photo>(collectionName)
                .DeleteOneAsync(Builders<Photo>.Filter.Eq("_id", objectId));
        }
    }
}