
namespace MyApp.Application.Features.CQRS.Commands.Content
{
    public class UpdateContentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
