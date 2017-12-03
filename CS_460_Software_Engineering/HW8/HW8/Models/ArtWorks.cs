using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class ArtWorks
    {
        public ArtWorks()
        {
            Classifications = new HashSet<Classifications>();
        }

        [Key]
        [Required]
        public int ArtWorkId { get; set; }

        [Required]
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        public virtual Artists Artists { get; set; }

        public virtual ICollection<Classifications> Classifications { get; set; }
    }
}