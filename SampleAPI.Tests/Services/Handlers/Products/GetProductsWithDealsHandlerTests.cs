using System.Linq;
using System.Threading.Tasks;
using SampleAPI.Contract.Deals;
using SampleAPI.Contract.Products;
using SampleAPI.Services.Handlers.Products;
using SampleAPI.Tests.Fixtures;
using Xunit;

namespace SampleAPI.Tests.Services.Handlers.Products
{
    public class GetProductsWithDealsHandlerTests : IClassFixture<InventoryContextFixture>
    {
        private readonly InventoryContextFixture _fixture;

        public GetProductsWithDealsHandlerTests(InventoryContextFixture f)
        {
            _fixture = f;
        }

        [Fact(DisplayName = "GetProductsWithDealsHandler - Multiple Active Deals are summed appropriately")]
        public async Task MultipleActiveDeals_DealPctSummed()
        {
            var handler = new GetProductsWithDealsHandler(_fixture.Context);
            var request = new GetProductsWithDealsRequest();
            var response = await handler.Handle(request);
            var productWithMultipleDeals = response.Single(x => x.ProductId == 2);
            Assert.Equal(24.00m, productWithMultipleDeals.CurrentPrice);
        }

        [Fact(DisplayName = "GetProductsWithDealsHandler - Only returns products with active deals")]
        public async Task OnlyProducts_WithActiveDeals_AreReturned()
        {
            var handler = new GetProductsWithDealsHandler(_fixture.Context);
            var request = new GetProductsWithDealsRequest();
            var response = await handler.Handle(request);
            Assert.Equal(2, response.Count());
        }
    }
}
