using ECommerceAPI.Application.Features.Carts.Commands.Create;
using ECommerceAPI.Application.Features.Carts.Queries.GetCartByCustomerId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CartController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpGet]
        [Route("getByCustomerId/{customerId}")]
        public async Task<IActionResult> GetCartByCustomerId(int customerId)
        {
            var response = await _mediatR.Send(new GetCartByCustomerIdRequest(customerId));
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCartCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}
