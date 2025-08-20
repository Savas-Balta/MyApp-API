
namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IRepository<Category> _repository;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository, ICacheService cacheService, IMapper mapper)
        {
            _repository = repository;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _cacheService.GetOrSetAsync<GetCategoryByIdQueryResult>(
                key: CacheKeys.CategoryById(request.Id),
                factory: async () =>
                {
                    var entity = await _repository.GetByIdAsync(request.Id);
                    if (entity is null)
                    {
                        return null;
                    }
                    return _mapper.Map<GetCategoryByIdQueryResult>(entity);
                },
                ttl: TimeSpan.FromMinutes(5),
                cancellationToken: cancellationToken
                );

            if (result is null) throw new KeyNotFoundException("Kategori bulunamadı.");

            return result;

        }
    }
}
