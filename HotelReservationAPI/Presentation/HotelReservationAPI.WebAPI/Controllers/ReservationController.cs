using HotelReservationAPI.Application.Features.Reservations.Commands.Create;
using HotelReservationAPI.Application.Features.Reservations.Commands.CreateWithCustomer;
using HotelReservationAPI.Application.Features.Reservations.Commands.Delete;
using HotelReservationAPI.Application.Features.Reservations.Commands.Update;
using HotelReservationAPI.Application.Features.Reservations.Queries.GetAll;
using HotelReservationAPI.Application.Features.Reservations.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public ReservationController(IMediator medaitR) {
            _mediatR = medaitR;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllReservationsRequest());
            return Ok(response);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediatR.Send(new GetByIdReservationRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("createWithCustomer")]
        public async Task<IActionResult> CreateWithCustomer([FromBody] CreateReservationWithCustomerCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateReservationCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediatR.Send(new DeleteReservationCommand(id));
            return Ok(response);
        }

        
    }
}
