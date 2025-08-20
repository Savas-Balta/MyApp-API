
namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IRepository<Category> _repository;
        private readonly ICacheService _cacheService;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Kategori bulunamadı.");
            value.Name = request.Name;

            await _repository.UpdateAsync(value);

            await _cacheService.RemoveAsync(CacheKeys.CategoriesAll, cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.CategoryById(request.Id), cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.ContentsAll, cancellationToken);
            return Unit.Value;
        }
    }
}
