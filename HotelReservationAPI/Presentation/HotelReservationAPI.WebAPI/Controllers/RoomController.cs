using HotelReservationAPI.Application.Features.Customers.Commands.Update;
using HotelReservationAPI.Application.Features.Rooms.Commands.Create;
using HotelReservationAPI.Application.Features.Rooms.Commands.Delete;
using HotelReservationAPI.Application.Features.Rooms.Commands.Update;
using HotelReservationAPI.Application.Features.Rooms.Queries.GetAll;
using HotelReservationAPI.Application.Features.Rooms.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public RoomController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllRoomsRequest());
            return Ok(response);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediatR.Send(new GetByIdRoomRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoomCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRoomCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediatR.Send(new DeleteRoomCommand(id));
            return Ok(response);
        }
    }
}
