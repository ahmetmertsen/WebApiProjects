using ECommerceAPI.Application.Features.Addresses.Commands.Create;
using ECommerceAPI.Application.Features.Addresses.Commands.Delete;
using ECommerceAPI.Application.Features.Addresses.Commands.Update;
using ECommerceAPI.Application.Features.Addresses.Queries.GetAll;
using ECommerceAPI.Application.Features.Addresses.Queries.GetAllByUserId;
using ECommerceAPI.Application.Features.Addresses.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public AddressController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllAddressesRequest());
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var response = await _mediatR.Send(new GetAllAddressesByUserIdRequest(userId));
            return Ok(response);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediatR.Send(new GetByIdAddressRequest(id));
            return Ok(response);
        }

  
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateAddressCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAddressCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediatR.Send(new DeleteAddressCommand(id));
            return Ok(response);
        }
    }
}
