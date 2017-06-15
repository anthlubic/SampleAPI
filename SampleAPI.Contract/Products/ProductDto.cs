using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Contract.Products
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
