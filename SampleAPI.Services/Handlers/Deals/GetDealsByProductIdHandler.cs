using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Contract.Deals;
using SampleAPI.Persistence.Inventory;
using StructureMap.Diagnostics;

namespace SampleAPI.Services.Handlers.Deals
{
    public class GetDealsByProductIdHandler : IAsyncRequestHandler<GetDealsByProductIdRequest, IEnumerable<DealDto>>
    {
        private readonly InventoryContext _context;
        public GetDealsByProductIdHandler(InventoryContext ctx)
        {
            _context = ctx;
        }
        public async Task<IEnumerable<DealDto>> Handle(GetDealsByProductIdRequest message)
        {
            var deals = from d in _context.Deals
                        join pd in _context.ProductDeals on d.DealId equals pd.DealId
                        join p in _context.Products on pd.ProductId equals p.ProductId
                        where pd.ProductId == message.ProductId
                        select new
                        {
                            pd.IsActive,
                            d.DealId,
                            p.ProductId,
                            d.PercentOff,
                            OriginalPrice = p.Price,
                            ProductName = p.Name
                        };

            if (message.ActiveDealsOnly)
            {
                deals = deals.Where(d => d.IsActive);
            }

            return await deals.Select(x => new DealDto
            {
                DealId = x.DealId,
                ProductId = x.ProductId,
                OriginalPrice = x.OriginalPrice,
                PercentOff = x.PercentOff,
                ProductName = x.ProductName
            }).ToListAsync();

        }
    }
}
