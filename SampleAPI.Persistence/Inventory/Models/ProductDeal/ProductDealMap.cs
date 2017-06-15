using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAPI.Persistence.Extensions;

namespace SampleAPI.Persistence.Inventory.Models.ProductDeal
{
    public class ProductDealMap : EntityTypeConfiguration<ProductDeal>
    {
        public override void Map(EntityTypeBuilder<ProductDeal> builder)
        {
            builder.ToTable("ProductDeal");

            builder.HasKey(x => x.ProductDealId);

            builder.Property(x => x.ProductId).IsRequired().HasColumnName("ProductId");
            builder.Property(x => x.DealId).IsRequired().HasColumnName("DealId");
            builder.Property(x => x.IsActive).IsRequired().HasColumnName("IsActive");

            builder.Property(x => x.CreatedBy).IsRequired().HasColumnName("CreatedBy");
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        }
    }
}
