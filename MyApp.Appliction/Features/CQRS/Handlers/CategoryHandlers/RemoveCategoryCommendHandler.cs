
namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommendHandler : IRequestHandler<RemoveCategoryCommand, Unit>
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommendHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
            return Unit.Value;
        }
    }
}
