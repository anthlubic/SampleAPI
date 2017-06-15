using System;

namespace SampleAPI.Persistence.Inventory.Models.ProductDeal
{
    public class ProductDeal
    {
        public int ProductDealId { get; set; }
        public int ProductId { get; set; }
        public int DealId { get; set; }
        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
