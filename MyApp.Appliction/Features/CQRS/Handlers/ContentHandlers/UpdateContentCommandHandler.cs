
namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    
    public class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand, Unit>
    {
        private readonly IRepository<Content> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateContentCommandHandler(IRepository<Content> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            var userIdFromToken = int.Parse(
            _httpContextAccessor.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0"
        );

            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new KeyNotFoundException("İçerik bulunamadı.");

            if (value.UserId != userIdFromToken)
                throw new UnauthorizedAccessException("Bu içeriği güncellemeye yetkiniz yok.");

            value.Body = request.Body;
            value.Title = request.Title;
            value.CategoryId = request.CategoryId;
            value.IsDeleted = request.IsDeleted;
            value.CreatedAt = request.CreatedAt;
            await _repository.UpdateAsync(value);
            return Unit.Value;
        }
    }
}
