using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationBaseIncludeIgnored
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LookupGroup> LookupGroups { get; set; }
        public DbSet<LookupValue> LookupValues { get; set; }
        public DbSet<LookupValueAttribute> LookupValueAttributes { get; set; }
    }
}
