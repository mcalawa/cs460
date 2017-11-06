using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class AddressChangeForm
    {
        public int Id = { get; set; }
        public string FullName = { get; set; }
        public string DoB = { get; set;}
        public string Address = { get; set;} 
        public string City = { get; set;} 
        public string State = { get; set;} 
        public string County = { get; set;} 
        public DateTime Date = { get; set;}
    }
}