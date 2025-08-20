
using MyApp.Application.Common.Caching;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetPublicContentsQueryHandler : IRequestHandler<GetPublicContentsQuery, List<ContentDto>>
    {
        private readonly IContentRepository _repository;
        private readonly ICacheService _cacheService;

        public GetPublicContentsQueryHandler(IContentRepository repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<List<ContentDto>> Handle(GetPublicContentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _cacheService.GetOrSetAsync(
                key: CacheKeys.ContentsAll,
                factory: () => _repository.GetAllContentsWithCategoryAndUserAsync(),
                ttl: TimeSpan.FromMinutes(2),
                cancellationToken: cancellationToken
            );

            return result ?? new List<ContentDto>();
        }
    }
}
