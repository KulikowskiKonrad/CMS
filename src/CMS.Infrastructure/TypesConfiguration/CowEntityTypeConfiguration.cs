using CMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.TypesConfiguration
{
    public class CowEntityTypeConfiguration : IEntityTypeConfiguration<Cow>
    {
        public void Configure(EntityTypeBuilder<Cow> builder)
        {
            builder.ToTable("Cows", CMSDbContext.DEFAULT_SCHEMA);

            builder.HasMany(x => x.InseminationsAsFather).WithOne(y => y.Father);
            builder.HasMany(x => x.InseminationsAsMother).WithOne(y => y.Mother);

            // builder.Property(x => x.InseminationsFathers).HasField("_InseminationsAsFather");
            var navigation = builder.Metadata.FindNavigation(nameof(Cow.InseminationsAsFather));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            navigation = builder.Metadata.FindNavigation(nameof(Cow.InseminationsAsMother));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            navigation = builder.Metadata.FindNavigation(nameof(Cow.Pregnancies));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            navigation = builder.Metadata.FindNavigation(nameof(Cow.Diseases));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            navigation = builder.Metadata.FindNavigation(nameof(Cow.Milkings));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.EarningNumber).IsRequired().HasMaxLength(10);
            builder.Property(x => x.PassportNumber).IsRequired().HasMaxLength(25);
            builder.Property(x => x.PseudoName).HasMaxLength(20);
            builder.HasOne(x => x.Mother);
            builder.HasOne(x => x.Father);
        }
    }
}
