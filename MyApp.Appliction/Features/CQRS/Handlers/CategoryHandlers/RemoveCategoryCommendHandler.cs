
namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommendHandler : IRequestHandler<RemoveCategoryCommand, Unit>
    {
        private readonly IRepository<Category> _repository;
        private readonly ICacheService _cacheService;

        public RemoveCategoryCommendHandler(IRepository<Category> repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Kategori bulunamadı.");
            if (!value.IsDeleted)
            {
                value.IsDeleted = true;
                await _repository.RemoveAsync(value);
            }

            await _cacheService.RemoveAsync(CacheKeys.CategoriesAll, cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.CategoryById(request.Id), cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.ContentsAll, cancellationToken);

            return Unit.Value;
        }
    }
}
