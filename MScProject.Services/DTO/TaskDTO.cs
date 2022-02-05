using System;

namespace MScProject.Services.DTO
{
    public class TaskDTO
    {
        public long Id { get; set; }
        public long ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}