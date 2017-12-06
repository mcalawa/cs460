using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Directors
    {
        [Key]
        [Required]
        public int DirectorId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }

}