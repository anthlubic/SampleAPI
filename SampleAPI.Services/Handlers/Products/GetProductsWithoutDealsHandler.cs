using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Contract.Products;
using SampleAPI.Persistence.Inventory;

namespace SampleAPI.Services.Handlers.Products
{
    public class GetProductsWithoutDealsHandler : IAsyncRequestHandler<GetProductsWithoutDealsRequest, IEnumerable<ProductDto>>
    {
        private readonly InventoryContext _context;
        public GetProductsWithoutDealsHandler(InventoryContext ctx)
        {
            _context = ctx;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsWithoutDealsRequest message)
        {
            //generate a left join to grab products with inactive deals and without any deals at all
            //group by product in case multiple active deals exist.
            var results = await (
                from p in _context.Products
                join pd in _context.ProductDeals on p.ProductId equals pd.ProductId into pdLeftJoin
                from pdNoDeal in pdLeftJoin.DefaultIfEmpty()
                where pdNoDeal == null || !pdNoDeal.IsActive
                group p by new
                {
                    //group into anonymous type so i can change grouping easily in the future as requirements change.
                    p.ProductId,
                    p.Name,
                    p.Description,
                    p.Price
                } into pg
                select new ProductDto
                {
                    ProductId = pg.Key.ProductId,
                    Name = pg.Key.Name,
                    Description = pg.Key.Description,
                    CurrentPrice = pg.Key.Price
                }).ToListAsync();

            return results;
        }
    }
}
