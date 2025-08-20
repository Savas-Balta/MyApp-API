
namespace MyApp.Application.Features.CQRS.Commands.Content
{
    public class CreateContentCommand : IRequest<Unit>
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        
    }
}
