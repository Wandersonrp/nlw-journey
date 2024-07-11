using Microsoft.EntityFrameworkCore;
using TripPlanner.Domain.Entities;

namespace TripPlanner.Infrastructure.Data.Context;

public class TripPlannerDbContext : DbContext
{
    public TripPlannerDbContext(DbContextOptions<TripPlannerDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Trip> Trips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TripPlannerDbContext).Assembly);

        modelBuilder.Entity<User>(e =>
        {
            e.HasMany(e => e.Trips)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        });
    }
}
