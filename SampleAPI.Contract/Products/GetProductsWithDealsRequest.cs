using System;
using System.Text;
using MediatR;

namespace SampleAPI.Contract.Products
{
    public class GetProductsWithDealsRequest : IRequest<GetProductsWithDealsResponse>
    {
        //public int CategoryId { get; set; }
    }
}
