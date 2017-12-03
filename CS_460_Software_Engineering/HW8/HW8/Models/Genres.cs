using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class Genres
    {
        public Genres()
        {
            Classifications = new HashSet<Classifications>();
        }

        [Key]
        [Required]
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Classifications> Classifications { get; set; }
    }
}