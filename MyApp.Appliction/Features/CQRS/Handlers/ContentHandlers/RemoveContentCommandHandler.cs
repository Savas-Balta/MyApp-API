namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class RemoveContentCommandHandler : IRequestHandler<RemoveContentCommand, Unit>
    {
        private readonly IRepository<Content> _repository;
        private readonly ICacheService _cacheService;
        private readonly ICurrentUserService _currentUser;

        public RemoveContentCommandHandler(IRepository<Content> repository, IHttpContextAccessor httpContextAccessor, ICacheService cacheService, ICurrentUserService currentUser)
        {
            _repository = repository;
            _cacheService = cacheService;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(RemoveContentCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.GetUserId()
            ?? throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                throw new KeyNotFoundException("İçerik bulunamadı.");

            if (entity.UserId != userId)
                throw new UnauthorizedAccessException("Bu içeriği silmeye yetkiniz yok.");


            if (!entity.IsDeleted)                 
            {
                entity.IsDeleted = true;   
                await _repository.UpdateAsync(entity);
            }

            await _cacheService.RemoveAsync(CacheKeys.ContentsAll, cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.ContentById(entity.Id), cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.UserContents(userId), cancellationToken);
            return Unit.Value;
        }
    }
}
