using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SampleAPI.Contract.Products
{
    public class GetProductsWithoutDealsRequest : IRequest<IEnumerable<ProductDto>>
    {
        //public int CategoryId { get; set; }
    }
}
