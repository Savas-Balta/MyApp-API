
using MyApp.Application.Common.Caching;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, Unit>
    {
        private readonly IRepository<Content> _repository;
        private readonly ICacheService _cacheService;
        private readonly ICurrentUserService _currentUser;

        public CreateContentCommandHandler(IRepository<Content> repository, IHttpContextAccessor httpContextAccessor, ICacheService cacheService, ICurrentUserService currentUser)
        {
            _repository = repository;
            _cacheService = cacheService;
            _currentUser = currentUser;
        }
        public async Task<Unit> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
           var userId = _currentUser.GetUserId()
                ?? throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");

            var entity = new Content
            {
                Title = request.Title,
                Body = request.Body,
                CategoryId = request.CategoryId,
                UserId = userId
            };

            await _repository.CreateAsync(entity);
            await _cacheService.RemoveAsync(CacheKeys.ContentsAll,cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.UserContents(userId), cancellationToken);

            return Unit.Value;
        }
    }
}
