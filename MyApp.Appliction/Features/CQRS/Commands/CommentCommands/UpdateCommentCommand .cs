
namespace MyApp.Application.Features.CQRS.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
