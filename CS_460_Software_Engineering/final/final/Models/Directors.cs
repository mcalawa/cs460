using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Directors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Directors()
        {
            Movies = new HashSet<Movies>();
        }

        [Key]
        [Required]
        public int DirectorId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }

}