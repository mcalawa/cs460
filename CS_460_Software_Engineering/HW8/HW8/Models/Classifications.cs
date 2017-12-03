using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class Classifications
    {
        [Key]
        [Required]
        public int ClassificationId { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Art Work")]
        public int ArtWorkId { get; set; }

        public virtual ArtWorks ArtWorks { get; set; }

        public virtual Genres Genres { get; set; }
    }
}