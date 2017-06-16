using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using SampleAPI.Contract.Deals;
using SampleAPI.Persistence.Inventory;
using SampleAPI.Services.Handlers.Deals;
using SampleAPI.Tests.Fixtures;
using Xunit;

namespace SampleAPI.Tests.Services.Handlers.Deals
{
    public class GetDealsByProductIdHandlerTests : IClassFixture<InventoryContextFixture>
    {
        private readonly InventoryContextFixture _fixture;

        public GetDealsByProductIdHandlerTests(InventoryContextFixture f)
        {
            _fixture = f;
        }

        [Fact(DisplayName = "GetDealsByProductIdHandler - Empty IEnumerable when product has no deals")]
        public async Task WhenNoDeals_ReturnsEmptyArray()
        {
            var handler = new GetDealsByProductIdHandler(_fixture.Context);
            var request = new GetDealsByProductIdRequest { ProductId = 1200 };
            var response = await handler.Handle(request);
            Assert.False(response.Any());
        }

        [Fact(DisplayName = "GetDealsByProductIdHandler - ActiveDealsOnly does not return inactive deals")]
        public async Task ActiveDealsOnly_ReturnsOnlyActiveDeals()
        {
            var handler = new GetDealsByProductIdHandler(_fixture.Context);
            var request = new GetDealsByProductIdRequest { ProductId = 5, ActiveDealsOnly = true };
            var response = await handler.Handle(request);
            Assert.Equal(1, response.Count());
        }

        [Fact(DisplayName = "GetDealsByProductIdHandler - ActiveDealsOnly false includes inactive deals")]
        public async Task ActiveDealsOnly_False_ReturnsInactiveDeals()
        {
            var handler = new GetDealsByProductIdHandler(_fixture.Context);
            var request = new GetDealsByProductIdRequest { ProductId = 4, ActiveDealsOnly = false };
            var response = await handler.Handle(request);
            Assert.Equal(1, response.Count());
        }
    }
}
