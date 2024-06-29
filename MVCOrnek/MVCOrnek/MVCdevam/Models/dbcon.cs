using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace MVCdevam.Models
{
    public class dbcon:DbContext
    {
        public DbSet<urun> liste {  get; set; }
    }
}