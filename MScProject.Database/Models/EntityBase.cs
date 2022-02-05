using System.ComponentModel.DataAnnotations.Schema;

namespace MScProject.Database.Models
{
    public class EntityBase
    {
        [Column("id")]
        public long Id { get; set; }
    }
}