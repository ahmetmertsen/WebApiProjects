using ECommerceAPI.Application.Features.Orders.Commands.Create;
using ECommerceAPI.Application.Features.Orders.Commands.Update;
using ECommerceAPI.Application.Features.Orders.Queries.GetAll;
using ECommerceAPI.Application.Features.Orders.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public OrderController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("getAllByUserId/{id}")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var response = await _mediatR.Send(new GetAllOrdersByUserIdRequest(userId));
            return Ok(response);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediatR.Send(new GetByIdOrderRequest(id));
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("updateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

    }
}
