using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MScProject.Database.Models
{    
    [Table("task_list")]
    public class TaskList: EntityBase
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}