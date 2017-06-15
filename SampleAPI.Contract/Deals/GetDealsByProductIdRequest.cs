using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SampleAPI.Contract.Deals
{
    public class GetDealsByProductIdRequest : IRequest<GetDealsByProductIdResponse>
    {
        public int ProductId { get; set; }
        public bool ActiveDealsOnly { get; set; }
    }
}
