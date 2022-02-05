using System.Collections.Generic;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class PhotoService: IPhotoService
    {
        public IEnumerable<PhotoDTO> GetAllPhotos()
        {
            throw new System.NotImplementedException();
        }

        public PhotoDTO Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TaskDTO> GetTasks(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(PhotoDTO photo)
        {
            throw new System.NotImplementedException();
        }

        public void Update(PhotoDTO photo)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}