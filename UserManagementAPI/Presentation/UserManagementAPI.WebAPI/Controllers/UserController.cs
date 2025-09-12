using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Application.Features.Users.Commands.Create;
using UserManagementAPI.Application.Features.Users.Commands.Delete;
using UserManagementAPI.Application.Features.Users.Commands.Update;
using UserManagementAPI.Application.Features.Users.Queries.GetAll;
using UserManagementAPI.Application.Features.Users.Queries.GetById;

namespace UserManagementAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public UserController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediatR.Send(new GetAllUsersRequest());
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediatR.Send(new GetByIdUserRequest { Id = id});
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _mediatR.Send(new DeleteUserCommand(Id));
            return Ok(response);
        }

    }
}
