using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBeer.Domain.Entities;

namespace MyBeer.Infrastructure.Configurations;

internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(ingredient => ingredient.Id);
        builder.Property(ingredient => ingredient.Name)
               .IsRequired()
               .HasMaxLength(100);
    }
    
}