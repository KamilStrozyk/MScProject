using System;
using MScProject.Database.Entities;

namespace MScProject.Services.DTO
{
    public class TaskListDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string CreatedAt { get; set; }
    }
}