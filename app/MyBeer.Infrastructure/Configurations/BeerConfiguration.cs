using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBeer.Domain.Entities;

namespace MyBeer.Infrastructure.Configurations;

internal class BeerConfiguration : IEntityTypeConfiguration<Beer>
{
    public void Configure(EntityTypeBuilder<Beer> builder)
    {
        builder.HasKey(beer => beer.Id);
        builder.Property(beer => beer.Name)
               .IsRequired()
               .HasMaxLength(100);
    }
}