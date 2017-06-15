using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Persistence.Inventory.Models.Product
{
    public class Product
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
