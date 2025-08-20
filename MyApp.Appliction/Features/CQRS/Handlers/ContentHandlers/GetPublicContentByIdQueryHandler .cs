
using MyApp.Application.Common.Caching;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetPublicContentByIdQueryHandler : IRequestHandler<GetPublicContentByIdQuery, ContentDto?>
    {
        private readonly IContentRepository _repository;
        private readonly ICacheService _cacheService;

        public GetPublicContentByIdQueryHandler(IContentRepository repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<ContentDto?> Handle(GetPublicContentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _cacheService.GetOrSetAsync(
                key: CacheKeys.ContentById(request.Id),
                factory: () => _repository.GetPublicContentByIdAsync(request.Id),
                ttl: TimeSpan.FromMinutes(5),
                cancellationToken: cancellationToken
                );

            return result;
        }
    }
}
