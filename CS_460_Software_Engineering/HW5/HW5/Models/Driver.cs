using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Driver
    {
        /// <summary>
        /// A dummy key (in the sense that it is unnecessary information that isn't used for display
        /// purposes) to keep the code from producing a null exception when you try to assign a value
        /// from user input to DriverID through model binding.
        /// 
        /// (I don't really understand why this error is one that occurs, but this is intended as a 
        /// work around since it does.)
        /// </summary>
        [Key]
        public int TableItem { get; set; }

        /// <summary>
        /// The ID of the customer whose address we are updating. If I had more time, I'd love to 
        /// make it so that if you entered an ID that was in the database already, it updated your 
        /// current database entry, but I also need to stop my bad habit of doing more than I need
        /// to when I don't really have time to be working on extra features.
        /// </summary>
        [Required]
        [Display(Name = "ODL/Permit/ID/Customer #")]
        public int DriverID { get; set; } 

        /// <summary>
        /// The date of birth for the person whose address we are updating. The [DataType(DataType.Date)]
        /// forces the DateTime to display as just a date rather than both a date and a time. 
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// In the form, the select element I created has options that display full state names, but
        /// have values that match the state's abbreviations so that the format is standardized between
        /// each entry.
        /// </summary>
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        /// <summary>
        /// Error checking in the form requires this to be a 5-digit number.
        /// </summary>
        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "County")]
        public string County { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Address Change")]
        public DateTime DateOfChange { get; set; }
    }
}