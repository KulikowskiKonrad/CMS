using CMS.Domain.Models.CowAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.TypesConfiguration
{
    public class CowshedEntityTypeConfiguration : IEntityTypeConfiguration<Cowshed>
    {
        public void Configure(EntityTypeBuilder<Cowshed> builder)
        {
            builder.ToTable("Cowsheds", CMSDbContext.DEFAULT_SCHEMA);

            var navigation = builder.Metadata.FindNavigation(nameof(Cowshed.Cows));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
        }
    }
}
