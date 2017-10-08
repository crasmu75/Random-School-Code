using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuropeanUnion.Models
{
    public class CountryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
    }
}