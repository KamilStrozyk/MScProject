using System.Collections.Generic;
using System.Threading.Tasks;
using MScProject.Services.DTO;

namespace MScProject.Services.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<IEnumerable<PhotoDTO>> GetAllPhotos();
        Task<PhotoDTO> Get(string id);
        Task<IEnumerable<TaskDTO>> GetTasks(string id);
        Task Create(PhotoDTO photo);
        Task Update(PhotoDTO photo);
        Task Delete(string id);
    }
}