using Booli.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.Json;

namespace Booli
{
    class BooliContext : DbContext
    {
        public DbSet<Sold> Sold { get; set; }
        public DbSet<Source> Sources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            try
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["connectionString"]);
            }
            catch(ArgumentNullException)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Booli;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().Property(p => p.namedAreas).HasConversion(
                v => JsonSerializer.Serialize(v, default),
                v => JsonSerializer.Deserialize<List<string>>(v, default));
        }
    }
}
