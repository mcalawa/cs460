using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW7.Models;
using System.Data.Entity;

namespace HW7.DAL
{
    public class SearchLogContext : DbContext
    {
        public SearchLogContext() : base("name=GiphyQueryLog")
        { }

        public virtual DbSet<SearchLog> SearchLogs { get; set; }
    }
}