
namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetContentQueryHandler : IRequestHandler<GetContentQuery, List<ContentDto>>
    {
        private readonly IContentRepository _repository;
        private readonly ICacheService _cacheService;

        public GetContentQueryHandler(IContentRepository repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<List<ContentDto>> Handle(GetContentQuery request, CancellationToken cancellationToken)
        {
            var result = await _cacheService.GetOrSetAsync(
                key: "contents:all",
                factory: () => _repository.GetAllContentsWithCategoryAndUserAsync(),
                ttl: TimeSpan.FromMinutes(2),
                cancellationToken: cancellationToken
            );

            return result ?? new List<ContentDto>();
        }
    }
}
