using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Driver
    {
        public int Id { get; set; } //ID for the driver
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public DateTime DateOfChange { get; set; }
    }
}