﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.API.Controllers
{
    [ApiController]
    [Route("api/photo")]
    public class PhotoController : ControllerBase
    {

        private readonly ILogger<PhotoController> _logger;
        private readonly IPhotoService _photoService;
        
        public PhotoController(ILogger<PhotoController> logger, IPhotoService photoService)
        {
            _logger = logger;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoDTO>> GetAll()
            => await _photoService.GetAllPhotos();
        
        [HttpGet("{id}")]
        public async Task<PhotoDTO> GetPhoto(string id)
            => await _photoService.Get(id);
        
        [HttpGet("{id}/tasks")]
        public async Task<IEnumerable<TaskDTO>> GetPhotoTasks(string id)
            => await _photoService.GetTasks(id);
        
        [HttpPost]
        public async Task CreatePhoto([FromBody] PhotoDTO photo)
            => await _photoService.Create(photo);
        
        [HttpPut]
        public async Task UpdatePhoto([FromBody] PhotoDTO photo)
            => await _photoService.Update(photo);
        
        [HttpDelete("{id}")]
        public async Task DeletePhoto(string id)
            => await _photoService.Delete(id);
    }
}