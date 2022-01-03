using Microsoft.EntityFrameworkCore;
using SampleREST_API.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models
{
    public class RESTAPIDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public RESTAPIDbContext(DbContextOptions<RESTAPIDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .HasKey( a => a.Name );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-O2A200U\GHOSTWALKER;Initial Catalog=REST_API_DB; Integrated Security=True");
        }

    }

}
