
namespace MyApp.Application.Features.CQRS.Handlers.ContentVoteHandlers
{
    public class CreateContentVoteCommandHandler : IRequestHandler<CreateContentVoteCommand, Unit>
    {
        private readonly IRepository<ContentVote> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateContentVoteCommandHandler(IRepository<ContentVote> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<Unit> Handle(CreateContentVoteCommand request, CancellationToken cancellationToken)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out var userId) || userId <= 0)
            {
                throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");
            }

            var existingVote = await _repository.GetByFilterAsync(v =>
                v.UserId == userId && v.ContentId == request.ContentId);

            if (existingVote != null)
            {
                existingVote.IsLike = request.IsLike;
                await _repository.UpdateAsync(existingVote);
            }
            else
            {
                await _repository.CreateAsync(new ContentVote
                {
                    ContentId = request.ContentId,
                    UserId = userId,
                    IsLike = request.IsLike
                });
            }

            return Unit.Value;
        }
    }
}
