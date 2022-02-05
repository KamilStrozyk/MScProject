using System.ComponentModel.DataAnnotations.Schema;

namespace MScProject.Database.Models
{    
    [Table("task_photo")]
    public class TaskPhoto
    {
        [Column("task_id")]
        public long TaskId { get; set; }
        [Column("photo_id")]
        public long PhotoId { get; set; }
    }
}