
namespace MyApp.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Comment created successfully" });
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Comment updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveCommentCommand (id));
            return Ok(new { message = "Comment deleted successfully" });
        }

        [HttpGet("content/{contentId}")]
        public async Task<IActionResult> GetByContent(int contentId)
        {
            var result = await _mediator.Send(new GetCommentsByContentIdQuery(contentId));
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var result = await _mediator.Send(new GetCommentsByUserIdQuery(userId));
            return Ok(result);
        }
    }
}
