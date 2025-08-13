
namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class RemoveContentCommandHandler : IRequestHandler<RemoveContentCommand, Unit>
    {
        private readonly IRepository<Content> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RemoveContentCommandHandler(IRepository<Content> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(RemoveContentCommand request, CancellationToken cancellationToken)
        {
            var userIdFromToken = int.Parse(
                _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0"
            );

            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
                throw new KeyNotFoundException("İçerik bulunamadı.");

            if (value.UserId != userIdFromToken)
                throw new UnauthorizedAccessException("Bu içeriği silmeye yetkiniz yok.");

            
            value.IsDeleted = true;
            await _repository.UpdateAsync(value);

            return Unit.Value;
        }
    }
}
