using CognizantQLESS.Core;
using CognizantQLESS.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CognizantQLESS.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Travel>()
                .HasOne(b => b.OriginStation)
                .WithMany(b => b.TravelsAsOrigin)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Travel>()
                .HasOne(b => b.DestinationStation)
                .WithMany(b => b.TravelsAsDestination)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Fare>()
                .HasOne(b => b.OriginStation)
                .WithMany(b => b.FaresAsOrigin)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Fare>()
                .HasOne(b => b.DestinationStation)
                .WithMany(b => b.FaresAsDestination)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<TransportCard> TransportCards { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<StationLine> StationLines { get; set; }
        public DbSet<Fare> Fares { get; set; }
        public DbSet<LoadHistory> LoadHistories { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../CognizantQLESS.Site/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
