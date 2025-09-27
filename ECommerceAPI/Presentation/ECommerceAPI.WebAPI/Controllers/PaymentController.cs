using ECommerceAPI.Application.Features.Payments.Commands.Create;
using ECommerceAPI.Application.Features.Payments.Commands.UpdatePaymentStatus;
using ECommerceAPI.Application.Features.Payments.Queries.GetAll;
using ECommerceAPI.Application.Features.Payments.Queries.GetById.GetPaymentById;
using ECommerceAPI.Application.Features.Payments.Queries.GetById.GetPaymentByOrderId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public PaymentController(IMediator mediatR) 
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllPaymentsRequest());
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediatR.Send(new GetPaymentByIdRequest(id));
            return Ok(response);
        }

        [HttpGet]
        [Route("getByOrderId/{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var response = await _mediatR.Send(new GetPaymentByOrderIdRequest(orderId));
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreatePaymentCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("updateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdatePaymentStatusCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }




    }
}
