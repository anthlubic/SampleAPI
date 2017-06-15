using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SampleAPI.Contract.Deals
{
    public class GetDealsByProductIdRequest : IRequest<IEnumerable<DealDto>>
    {
        public int ProductId { get; set; }
        public bool ActiveDealsOnly { get; set; }
    }
}
