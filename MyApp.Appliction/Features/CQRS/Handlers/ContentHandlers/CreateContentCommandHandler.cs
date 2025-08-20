namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, Unit>
    {
        private readonly IRepository<Content> _repository;
        private readonly ICacheService _cacheService;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public CreateContentCommandHandler(IRepository<Content> repository, ICacheService cacheService, ICurrentUserService currentUser, IMapper mapper)
        {
            _repository = repository;
            _cacheService = cacheService;
            _currentUser = currentUser;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
           var userId = _currentUser.GetUserId()
                ?? throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");

            var entity = _mapper.Map<Content>(request);
            entity.UserId = userId;

            await _repository.CreateAsync(entity);
            await _cacheService.RemoveAsync(CacheKeys.ContentsAll,cancellationToken);
            await _cacheService.RemoveAsync(CacheKeys.UserContents(userId), cancellationToken);

            return Unit.Value;
        }
    }
}
