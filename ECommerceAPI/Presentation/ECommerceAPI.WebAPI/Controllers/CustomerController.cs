using ECommerceAPI.Application.Features.Customers.Commands.Create;
using ECommerceAPI.Application.Features.Customers.Commands.Delete;
using ECommerceAPI.Application.Features.Customers.Commands.Update;
using ECommerceAPI.Application.Features.Customers.Queries.GetAll;
using ECommerceAPI.Application.Features.Customers.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public CustomerController(IMediator mediatR) 
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllCustomersRequest());
            return Ok(response);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediatR.Send(new GetByIdCustomerRequest(id));
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediatR.Send(new DeleteCustomerCommand(id));
            return Ok(response);
        }
    }
}
