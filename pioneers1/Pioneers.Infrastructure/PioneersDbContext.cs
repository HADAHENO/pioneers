using Microsoft.EntityFrameworkCore;
using Pioneers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Infrastructure;

public class PioneersDbContext : DbContext
{
    public PioneersDbContext(DbContextOptions<PioneersDbContext> options) : base(options) { }

    public DbSet<Country> Countries => Set<Country>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Country>(e =>
        {
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.HasIndex(x => x.Name).IsUnique();
        });

        b.Entity<City>(e =>
        {
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.HasOne(x => x.Country).WithMany(c => c.Cities).HasForeignKey(x => x.CountryId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<Customer>(e =>
        {
            e.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            e.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            e.Property(x => x.Email).IsRequired().HasMaxLength(200);
            e.Property(x => x.Phone).IsRequired().HasMaxLength(30);
            e.HasIndex(x => x.Email).IsUnique();

            e.HasOne(x => x.City).WithMany(c => c.Customers).HasForeignKey(x => x.CityId)
             .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Country).WithMany(c => c.Customers).HasForeignKey(x => x.CountryId)
             .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
