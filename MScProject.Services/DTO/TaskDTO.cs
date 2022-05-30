using System;

namespace MScProject.Services.DTO
{
    public class TaskDTO
    {
        public string Id { get; set; }
        public string ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Photos { get; set; }
    }
}