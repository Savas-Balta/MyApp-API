
using MyApp.Application.Common.Caching;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetContentByIdQueryHandler : IRequestHandler<GetContentByIdQuery, GetContentByIdQueryResult>
    {
        private readonly IContentRepository _repository;
        private readonly ICacheService _cacheService;

        public GetContentByIdQueryHandler(IContentRepository repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<GetContentByIdQueryResult> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _cacheService.GetOrSetAsync(
                key: CacheKeys.ContentById(request.Id),
                factory: () => _repository.GetContentWithCategoryAndUserByIdAsync(request.Id),
                ttl: TimeSpan.FromMinutes(5),
                cancellationToken : cancellationToken
                );

            if (result is null) throw new KeyNotFoundException("İçerik bulunamadı.");

            return result;
        }
    }
}
