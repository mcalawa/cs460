using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Casts
    {
        [Key]
        [Required]
        public int CastId { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Actor")]
        public int ActorId { get; set; }

        public virtual Movies Movies { get; set; }

        public virtual Actors Actors { get; set; }
    }
}