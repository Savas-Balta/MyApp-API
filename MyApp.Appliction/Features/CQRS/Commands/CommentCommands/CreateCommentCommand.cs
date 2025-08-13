
namespace MyApp.Application.Features.CQRS.Commands.CommentCommands
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Text { get; set; } = string.Empty;
        public int ContentId { get; set; }
    }
}
