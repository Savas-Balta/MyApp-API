using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.CQRS.Commands.CategoryCommends;
using MyApp.Application.Features.CQRS.Commands.UserCommands;
using MyApp.Application.Features.CQRS.Queries.CategoryQueries;
using MyApp.Application.Features.CQRS.Queries.UserQueries;

namespace MyApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUserQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
