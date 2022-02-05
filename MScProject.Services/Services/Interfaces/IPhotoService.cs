using System.Collections.Generic;
using MScProject.Services.DTO;

namespace MScProject.Services.Services.Interfaces
{
    public interface IPhotoService
    {
        IEnumerable<PhotoDTO> GetAllPhotos();
        PhotoDTO Get(long id);
        IEnumerable<TaskDTO> GetTasks(long id);
        void Create(PhotoDTO photo);
        void Update(PhotoDTO photo);
        void Delete(long id);
    }
}