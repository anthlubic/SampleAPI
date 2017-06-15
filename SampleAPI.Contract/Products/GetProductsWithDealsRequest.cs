using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SampleAPI.Contract.Products
{
    public class GetProductsWithDealsRequest : IRequest<IEnumerable<ProductDto>>
    {
        //public int CategoryId { get; set; }
    }
}
