
namespace MyApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentVoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContentVoteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("vote")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> CreateVote(CreateContentVoteCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Vote successfully recorded." });
        }

        [HttpGet("user/{contentId}")]
        public async Task<IActionResult> GetUserVote(int contentId)
        {
            var result = await _mediator.Send(new GetUserContentVoteQuery(contentId));
            return Ok(result);
        }
    }
}
