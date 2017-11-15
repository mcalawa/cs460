using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW5.Models;
using System.Data.Entity;

namespace HW5.DAL
{
    public class DriverContext : DbContext
    {
        public DriverContext() : base("name=HW5Database")
        { }

        public virtual DbSet<Driver> Drivers { get; set; }
    }
}