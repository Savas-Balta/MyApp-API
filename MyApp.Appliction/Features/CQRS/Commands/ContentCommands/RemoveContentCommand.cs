
namespace MyApp.Application.Features.CQRS.Commands.Content
{
    public class RemoveContentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public RemoveContentCommand(int id)
        {
            Id = id;
        }
    }
}
