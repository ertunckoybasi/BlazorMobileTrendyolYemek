using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Features;
using Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<TrendyolYemekOrder>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<List<Content>>> GetOrders()
        {
            var query = new GetOrdersQuery();
            var customerResponse = await _mediator.Send(query);
            if (!customerResponse.Any()) return NoContent();
            return Ok(customerResponse);

        }
    }
}
