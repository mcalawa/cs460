using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    public class SearchLog
    {
        [Key]
        public int SearchID { get; set; }

        [Required]
        public string SearchQuery { get; set; }

        [Required]
        public int NumberRequested { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        public string RequesterIP { get; set; }

        [Required]
        public string BrowserAgent { get; set; }
    }
}