using ECommerceAPI.Application.Features.Carts.Commands.Create;
using ECommerceAPI.Application.Features.CartsItems.Commands.Create;
using ECommerceAPI.Application.Features.CartsItems.Commands.Delete;
using ECommerceAPI.Application.Features.CartsItems.Commands.Update;
using ECommerceAPI.Application.Features.CartsItems.Queries.GetAll;
using ECommerceAPI.Application.Features.CartsItems.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CartItemController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("getAllByCartId/{cartId}")]
        public async Task<IActionResult> GetAllByCartId(int cartId)
        {
            var response = await _mediatR.Send(new GetAllCartItemsByCartIdRequest(cartId));
            return Ok(response);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediatR.Send(new GetByIdCartItemRequest(id));
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCartItemCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCartItemCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediatR.Send(new DeleteCartItemCommand(id));
            return Ok(response);
        }


    }
}
