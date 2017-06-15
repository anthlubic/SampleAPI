using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAPI.Persistence.Extensions;

namespace SampleAPI.Persistence.Inventory.Models.Product
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public override void Map(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductId).IsRequired().HasColumnName("ProductId");
            builder.Property(x => x.Price).IsRequired().HasColumnType("money").HasColumnName("Price");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256).HasColumnName("Name");
            builder.Property(x => x.Description).IsRequired().HasColumnName("Description");

            builder.Property(x => x.CreatedBy).IsRequired().HasColumnName("CreatedBy");
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        }
    }
}
