using Microsoft.EntityFrameworkCore;
using MyBeer.Domain.Entities;
using MyBeer.Infrastructure.Models;
using MyBeer.Infrastructure.Configurations;


namespace MyBeer.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Beer> Beers => Set<Beer>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<BeerIngredient> BeerIngredients => Set<BeerIngredient>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BeerConfiguration());
        builder.ApplyConfiguration(new IngredientConfiguration());
        builder.ApplyConfiguration(new BeerIngredientConfiguration());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var entries = ChangeTracker
            .Entries<Beer>()
            .Where(e => e.State == EntityState.Modified);

        return base.SaveChangesAsync(cancellationToken);
    }
}
