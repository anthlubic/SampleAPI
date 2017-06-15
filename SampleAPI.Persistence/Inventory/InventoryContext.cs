using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Persistence.Extensions;
using SampleAPI.Persistence.Inventory.Models.Deal;
using SampleAPI.Persistence.Inventory.Models.Product;
using SampleAPI.Persistence.Inventory.Models.ProductDeal;

namespace SampleAPI.Persistence.Inventory
{
    public partial class InventoryContext : DbContext
    {
        //TODO: split partial into separate files when amount of DbSets/Configuration gets too large
        public InventoryContext()
        { }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        { }

        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDeal> ProductDeals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ProductMap());
            modelBuilder.AddConfiguration(new ProductDealMap());
            modelBuilder.AddConfiguration(new DealMap());
        }
    }
}
