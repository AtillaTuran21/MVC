using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace urunfiltreleme.Models
{
    public class dbcontext:DbContext
    {
        public DbSet<Urun> urunler { get; set; }
    }
}