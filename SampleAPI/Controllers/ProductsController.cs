using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Contract.Products;
using SampleAPI.Infrastructure;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator) : base(mediator) { }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync(bool withDeals = false)
        {
            IEnumerable<ProductDto> response;
            if (withDeals)
            {
                response = await Mediator.Send(new GetProductsWithDealsRequest());
            }
            else
            {
                response = await Mediator.Send(new GetProductsWithoutDealsRequest());
            }

            return Ok(response);
        }
    }
}
