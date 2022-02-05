using System.ComponentModel.DataAnnotations.Schema;

namespace MScProject.Database.Models
{    
    [Table("photo")]
    public class Photo: EntityBase
    {
        
        [Column("content")]
        public byte[] Content { get; set; }
    }
}