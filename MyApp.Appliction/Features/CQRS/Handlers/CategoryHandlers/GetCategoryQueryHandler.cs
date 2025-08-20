namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly IRepository<Category> _repository;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;
        public GetCategoryQueryHandler(IRepository<Category> repository, ICacheService cacheService, IMapper mapper)
        {
            _repository = repository;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _cacheService.GetOrSetAsync(
           key: CacheKeys.CategoriesAll,
           factory: async () =>
           {
               var cats = await _repository.GetAllAsync();
               return _mapper.Map<List<GetCategoryQueryResult>>(cats);
           },
           ttl: TimeSpan.FromMinutes(30),
           cancellationToken: cancellationToken
       ) ?? new();
        }
    }
}