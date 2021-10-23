using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationApp.Models
{
    public class LocalizationContext : DbContext
    {
        public LocalizationContext(DbContextOptions<LocalizationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Resource> Resources { get; set; }
    }
}
