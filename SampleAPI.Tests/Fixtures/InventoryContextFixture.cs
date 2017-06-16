using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Networking;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Persistence.Inventory;

namespace SampleAPI.Tests.Fixtures
{
    public class InventoryContextFixture : IDisposable
    {
        public InventoryContext Context { get; }

        public InventoryContextFixture()
        {
            var builder = new DbContextOptionsBuilder<InventoryContext>();
            builder.UseInMemoryDatabase($"database{Guid.NewGuid()}");
            Context = new InventoryContext(builder.Options);

            Context.Products.AddRange(InventorySeed.GetProducts());
            Context.Deals.AddRange(InventorySeed.GetDeals());
            Context.ProductDeals.AddRange(InventorySeed.GetProductDeals());
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
