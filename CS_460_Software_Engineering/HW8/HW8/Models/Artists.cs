using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class Artists
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artists()
        {
            ArtWorks = new HashSet<ArtWorks>();
        }

        [Key]
        [Required]
        public int ArtistId { get; set; }

        [Required]
        [Display(Name = "Artist")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Birthplace")]
        public string BirthCity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DoB { get; set; }

        public virtual ICollection<ArtWorks> ArtWorks { get; set; }
    }
}