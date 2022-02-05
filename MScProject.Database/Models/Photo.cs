using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MScProject.Database.Models
{    
    [Table("photo")]
    public class Photo
    {
        [Column("id")]
        public long Id { get; set; }
        
        [Column("content")]
        public byte[] Content { get; set; }
    }
}