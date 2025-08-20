namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    
    public class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand, Unit>
    {
        private readonly IRepository<Content> _repository;
        private readonly ICacheService _cacheService;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;
        public UpdateContentCommandHandler(IRepository<Content> repository, IHttpContextAccessor httpContextAccessor, ICacheService cacheService, ICurrentUserService currentUser, IMapper mapper)
        {
            _repository = repository;
            _cacheService = cacheService;
            _currentUser = currentUser;
            _mapper = mapper;
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

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);

            await _cacheService.RemoveAsync(CacheKeys.ContentsAll, cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.ContentById(entity.Id), cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.UserContents(userId), cancellationToken);

            return Unit.Value;
        }
    }
}
