
using MyApp.Application.Common.Caching;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    
    public class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand, Unit>
    {
        private readonly IRepository<Content> _repository;
        private readonly ICacheService _cacheService;
        private readonly ICurrentUserService _currentUser;
        public UpdateContentCommandHandler(IRepository<Content> repository, IHttpContextAccessor httpContextAccessor, ICacheService cacheService, ICurrentUserService currentUser)
        {
            _repository = repository;
            _cacheService = cacheService;
            _currentUser = currentUser;
        }
        public async Task<Unit> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.GetUserId()
             ?? throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                throw new KeyNotFoundException("İçerik bulunamadı.");

            if (entity.UserId != userId)
                throw new UnauthorizedAccessException("Bu içeriği güncellemeye yetkiniz yok.");

            entity.Title = request.Title;
            entity.Body = request.Body;
            entity.CategoryId = request.CategoryId;
            await _repository.UpdateAsync(entity);

            await _cacheService.RemoveAsync(CacheKeys.ContentsAll, cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.ContentById(entity.Id), cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.UserContents(userId), cancellationToken);

            return Unit.Value;
        }
    }
}
