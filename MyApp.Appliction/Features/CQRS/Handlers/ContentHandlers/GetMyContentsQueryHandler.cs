using MyApp.Application.Common.Caching;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetMyContentsQueryHandler : IRequestHandler<GetMyContentsQuery, List<ContentDto>>
    {
        private readonly IContentRepository _contentRepository;
        private readonly ICacheService _cacheService;
        private readonly ICurrentUserService _currentUser;

        public GetMyContentsQueryHandler(IContentRepository contentRepository, IHttpContextAccessor httpContextAccessor, ICacheService cacheService, ICurrentUserService currentUser)
        {
            _contentRepository = contentRepository;
            _cacheService = cacheService;
            _currentUser = currentUser;
        }

        public async Task<List<ContentDto>> Handle(GetMyContentsQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.GetUserId()
                ?? throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");

            var result = await _cacheService.GetOrSetAsync(
                key: CacheKeys.UserContents(userId),
                factory: () => _contentRepository.GetUserContentsWithCategoryAndUserAsync(userId),
                ttl: TimeSpan.FromMinutes(2),
                cancellationToken : cancellationToken
                );

            return result ?? new List<ContentDto>();
        }
    }
}
