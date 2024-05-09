using MyBeer.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyBeer.Infrastructure.Configurations;

internal class BeerIngredientConfiguration
    : IEntityTypeConfiguration<BeerIngredient>
{
    public void Configure(EntityTypeBuilder<BeerIngredient> builder)
        => builder.HasKey(relation => new
        {
            relation.BeerId,
            relation.IngredientId
        });
}