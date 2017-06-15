using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Contract.Deals
{
    public class GetDealsByProductIdResponse
    {
        public IEnumerable<DealDto> Deals { get; set; }
    }
}
