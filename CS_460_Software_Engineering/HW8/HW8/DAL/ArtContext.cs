using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW8.Models;
using System.Data.Entity;

namespace HW8.DAL
{
    public class ArtContext : DbContext
    {
        public ArtContext() : base("name=HW8DB")
        { }

        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<ArtWorks> ArtWorks { get; set; }
        public virtual DbSet<Classifications> Classifications { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
    }
}