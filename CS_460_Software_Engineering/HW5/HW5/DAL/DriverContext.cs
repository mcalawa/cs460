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
        /// <summary>
        /// Connects the model class to the database
        /// </summary>
        public DriverContext() : base("name=HW5Database")
        { }

        /// <summary>
        /// Receives the data in the database so it can be displayed
        /// and added to
        /// </summary>
        public virtual DbSet<Driver> Drivers { get; set; }
    }
}