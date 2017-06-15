using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Contract.Products;
using SampleAPI.Persistence.Inventory;

namespace SampleAPI.Services.Handlers.Products
{
    public class GetProductsWithDealsHandler : IAsyncRequestHandler<GetProductsWithDealsRequest, IEnumerable<ProductDto>>
    {
        private readonly InventoryContext _context;

        public GetProductsWithDealsHandler(InventoryContext ctx)
        {
            _context = ctx;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsWithDealsRequest message)
        {
            var results = await
                (from pd in _context.ProductDeals
                join d in _context.Deals on pd.DealId equals d.DealId
                join p in _context.Products on pd.ProductId equals p.ProductId
                where pd.IsActive
                group d by new
                {
                    p.ProductId,
                    p.Name,
                    p.Description,
                    p.Price,
                } into dg
                let dealPct = dg.Sum(x => x.PercentOff)
                select new ProductDto
                {
                    ProductId = dg.Key.ProductId,
                    Name = dg.Key.Name,
                    Description = dg.Key.Description,
                    CurrentPrice = dg.Key.Price - dg.Key.Price * (dealPct > 1 ? 1 : dealPct)
                }).ToListAsync();

            return results;
        }
    }
}
