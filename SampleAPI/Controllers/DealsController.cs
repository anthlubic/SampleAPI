using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Contract.Deals;
using SampleAPI.Infrastructure;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    public class DealsController : BaseController
    {
        public DealsController(IMediator m) : base(m) {}

        public async Task<IActionResult> GetAsync()
        {
            var response = await Task.FromResult(new List<DealDto>());

            return BadRequest(response);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetDealsByProductAsync(int productId, bool activeDealsOnly = false)
        {
            var response = await Mediator.Send(new GetDealsByProductIdRequest { ProductId = productId, ActiveDealsOnly = activeDealsOnly });

            return Ok(response);
        }
    }
}
