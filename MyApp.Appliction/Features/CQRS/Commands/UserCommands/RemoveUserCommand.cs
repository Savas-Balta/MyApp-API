
namespace MyApp.Application.Features.CQRS.Commands.UserCommands
{
    public class RemoveUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public RemoveUserCommand(int id)
        {
            Id = id;
        }
    }
}
