
namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly IRepository<Category> _repository;
        private readonly ICacheService _cacheService;

        public CreateCategoryCommandHandler(IRepository<Category> repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Category { Name = request.Name });
            await _cacheService.RemoveAsync(CacheKeys.CategoriesAll, cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.ContentsAll, cancellationToken);

            return Unit.Value;

        }
    }
}
