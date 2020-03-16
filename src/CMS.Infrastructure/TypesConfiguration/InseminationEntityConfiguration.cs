using CMS.Domain.Models.CowAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Infrastructure.TypesConfiguration
{
    public class InseminationEntityConfiguration : IEntityTypeConfiguration<Insemination>
    {
        public void Configure(EntityTypeBuilder<Insemination> builder)
        {
            builder.HasOne(x => x.Mother).WithMany(y => y.InseminationsAsMother);
            builder.HasOne(x => x.Father).WithMany(y => y.InseminationsAsFather);
        }
    }
}
