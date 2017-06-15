using System.Collections.Generic;

namespace SampleAPI.Contract.Products
{
    public class GetProductsWithDealsResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}