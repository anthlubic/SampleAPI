using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAPI.Contract.Products;
using SampleAPI.Services.Handlers.Products;
using SampleAPI.Tests.Fixtures;
using Xunit;

namespace SampleAPI.Tests.Services.Handlers.Products
{
    public class GetProductsWithoutDealsHandlerTests : IClassFixture<InventoryContextFixture>
    {
        private readonly InventoryContextFixture _fixture;

        public GetProductsWithoutDealsHandlerTests(InventoryContextFixture f)
        {
            _fixture = f;
        }

        [Fact(DisplayName = "GetProductsWithoutDealsHandler - Only returns products without active deals")]
        public async Task OnlyProducts_WithoutActiveDeals()
        {
            var handler = new GetProductsWithoutDealsHandler(_fixture.Context);
            var request = new GetProductsWithoutDealsRequest();
            var response = await handler.Handle(request);
            Assert.Equal(3, response.Count());
        }
    }
}
