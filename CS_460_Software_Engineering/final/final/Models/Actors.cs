using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Actors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actors()
        {
            Casts = new HashSet<Casts>();
        }

        [Key]
        [Required]
        public int ActorId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Casts> Casts { get; set; }
    }
}