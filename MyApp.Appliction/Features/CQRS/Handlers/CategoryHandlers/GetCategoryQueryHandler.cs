namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly IRepository<Category> _repository;
        private readonly ICacheService _cacheService;

        public GetCategoryQueryHandler(IRepository<Category> repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _cacheService.GetOrSetAsync<List<GetCategoryQueryResult>>(
                 key: CacheKeys.CategoriesAll,
                 factory: async () =>
                 {
                     var cats = await _repository.GetAllAsync();
                     return cats.Select(c => new GetCategoryQueryResult
                     {
                         Id = c.Id,
                         Name = c.Name
                     }).ToList();
                 },
                 ttl: TimeSpan.FromMinutes(30),
                 cancellationToken: cancellationToken
             );

            return result ?? new List<GetCategoryQueryResult>();
        }
    }
}