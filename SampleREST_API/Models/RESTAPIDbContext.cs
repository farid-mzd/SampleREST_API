using Microsoft.EntityFrameworkCore;
using SampleREST_API.Models.Custom;
using SampleREST_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleREST_API.Models
{
    public class RESTAPIDbContext : DbContext
    {
        private readonly SqlConnectionConfiguration sqlConnectionConfiguration;

        public DbSet<Dog> Dogs { get; set; }

        public RESTAPIDbContext(DbContextOptions<RESTAPIDbContext> options, SqlConnectionConfiguration sqlConnectionConfiguration) : base(options)
        {
            this.sqlConnectionConfiguration = sqlConnectionConfiguration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Dog>()
              .HasKey(u => u.Name);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlConnectionConfiguration.Value);

        }

    }

}
