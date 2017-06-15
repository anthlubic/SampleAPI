using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Persistence.Inventory.Models.Deal
{
    public class Deal
    {
        public int DealId { get; set; }
        public string Name { get; set; }
        public decimal PercentOff { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
