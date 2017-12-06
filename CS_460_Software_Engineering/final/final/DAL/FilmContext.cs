using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using final.Models;
using System.Data.Entity;

namespace final.DAL
{
    public class FilmContext : DbContext
    {
        public FilmContext() : base("name=FilmDb")
        { }
        
        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Directors> Directors { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Casts> Casts { get; set; }
    }
}