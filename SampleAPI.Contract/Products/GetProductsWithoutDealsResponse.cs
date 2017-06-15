using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Contract.Products
{
    public class GetProductsWithoutDealsResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
