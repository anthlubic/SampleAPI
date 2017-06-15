using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SampleAPI.Contract.Deals;
using SampleAPI.Persistence.Inventory;

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
            throw new NotImplementedException();
        }
    }
}
