using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Movies
    {
        public Movies()
        {
            Casts = new HashSet<Casts>();
        }

        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Director")]
        public int DirectorId { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        public virtual Directors Directors { get; set; }

        public virtual ICollection<Casts> Casts { get; set; }
    }
}