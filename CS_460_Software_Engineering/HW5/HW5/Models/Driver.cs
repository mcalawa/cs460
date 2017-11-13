using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Driver
    {
        [Required]
        public int RecordID { get; set; }

        [Required]
        [Display(Name = "ODL/Permit/ID/Customer #")]
        public int DriverID { get; set; } //ID for the driver

        [Required]
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

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "County")]
        public string County { get; set; }

        [Required]
        [Display(Name = "Date of Address Change")]
        public DateTime DateOfChange { get; set; }
    }
}