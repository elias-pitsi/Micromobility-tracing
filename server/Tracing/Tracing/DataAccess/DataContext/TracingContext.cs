using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tracing.DataAccess.Models;

namespace Tracing.DataAccess.DataContext;

public class TracingContext : DbContext 
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public TracingContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    { }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<ComponentDetails> Components { get; set; }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<ComponentsHistory> ComponentsHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         modelBuilder.Entity<Owner>(p => 
         {
             p.ToContainer("Owner");
             p.HasPartitionKey(x => x.OwnerId);
             //p.HasMany(b => b.Bikes);
             //p.HasMany(c => c.Components);
             p.HasKey(k => k.OwnerId);
         });
         
         modelBuilder.Entity<Bike>(b =>
         {
             b.ToContainer("Bike");
             b.HasPartitionKey(x => x.BikeId);
             b.HasKey(k => k.BikeId);
         });
         
         modelBuilder.Entity<ComponentDetails>(p => 
         {
             p.ToContainer("ComponentDetails");
             p.HasPartitionKey(x => x.CompId);
            //p.HasOne(o => o.owner);
             //.WithMany(c => c.Components);
            // p.HasOne(b => b.bike).WithMany(c => c.Components);
             p.HasKey(k => k.CompId);
         });

        modelBuilder.Entity<ComponentsHistory>(c =>
        {
            c.ToContainer("ComponentsHistory");
            c.HasPartitionKey(x => x.CompId);
            //c.HasOne(o => o.owner).WithMany(c => c.ComponentsHistories);
            c.HasKey(k => k.CompId);
        });

     }
}