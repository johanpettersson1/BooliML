using Booli.ML.Data.Database.SoldModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;

namespace Booli.ML.Data.Database
{
    internal class BooliMLSoldContext : DbContext
    {
        public DbSet<Sold> Sold { get; set; }
        public DbSet<Source> Sources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BooliMLSold;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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