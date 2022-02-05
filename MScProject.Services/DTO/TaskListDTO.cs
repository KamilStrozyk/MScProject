using System;

namespace MScProject.Services.DTO
{
    public class TaskListDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}