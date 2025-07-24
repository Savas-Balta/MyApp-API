using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.CQRS.Commands.Content;
using MyApp.Application.Features.CQRS.Queries.Content;

namespace MyApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ContentList()
        {
            var result = await _mediator.Send(new GetContentQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ContentById(int id)
        {
            var result = await _mediator.Send(new GetContentByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> CreateContent(CreateContentCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Content created successfully" });
        }

        [HttpPut]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> UpdateContent(UpdateContentCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Content updated successfully" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> DeleteContent(int id)
        {
            await _mediator.Send(new RemoveContentCommand(id));
            return Ok(new { message = "Content deleted successfully" });
        }
    }
}
