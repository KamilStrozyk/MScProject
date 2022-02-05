using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MScProject.Database.Models
{    
    [Table("task_list")]
    public class TaskList
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}