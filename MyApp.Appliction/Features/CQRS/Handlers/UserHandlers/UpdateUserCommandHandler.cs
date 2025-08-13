
namespace MyApp.Application.Features.CQRS.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IRepository<User> _repository;

        public UpdateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.Id);
            value.Role = request.Role;
            value.UserName = request.UserName;

            await _repository.UpdateAsync(value);
            return Unit.Value;
        }
    }
}
