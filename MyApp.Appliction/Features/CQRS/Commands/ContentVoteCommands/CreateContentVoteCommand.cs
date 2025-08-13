
namespace MyApp.Application.Features.CQRS.Commands.ContentVoteCommands
{
    public class CreateContentVoteCommand : IRequest<Unit>
    {
        public int ContentId { get; set; }
        public bool IsLike { get; set; }
    }
}
