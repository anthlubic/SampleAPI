using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Contract.Deals
{
    public class DealDto
    {
        public int DealId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal PercentOff { get; set; }
        public decimal OriginalPrice { get; set; }

        public decimal DealPrice => OriginalPrice - OriginalPrice * PercentOff;
    }
}
