using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAPI.Persistence.Extensions;

namespace SampleAPI.Persistence.Inventory.Models.Deal
{
    public class DealMap : EntityTypeConfiguration<Deal>
    {
        public override void Map(EntityTypeBuilder<Deal> builder)
        {
            builder.ToTable("Deal");

            builder.HasKey(x => x.DealId);

            builder.Property(x => x.DealId).IsRequired().HasColumnName("DealId");
            builder.Property(x => x.PercentOff).HasColumnType("money").IsRequired().HasColumnName("PercentOff");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256).HasColumnName("Name");

            builder.Property(x => x.CreatedBy).IsRequired().HasColumnName("CreatedBy");
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        }
    }
}
