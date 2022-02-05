using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MScProject.Database.Models
{
    [Table("task")]
    public class Task
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("list_id")]
        public long ListId { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}