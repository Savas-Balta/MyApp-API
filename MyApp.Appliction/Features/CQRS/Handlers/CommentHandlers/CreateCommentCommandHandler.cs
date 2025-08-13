
namespace MyApp.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateCommentCommandHandler(IHttpContextAccessor httpContextAccessor, IRepository<Comment> repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdStr, out var userId) || userId <= 0)
            {
                throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");
            }

            var comment = new Comment
            {
                Text = request.Text,
                ContentId = request.ContentId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            if (string.IsNullOrWhiteSpace(comment.Text))
            {
                throw new ArgumentException("Yorum metni boş olamaz.");
            }

            await _repository.CreateAsync(comment);
            return Unit.Value;
        }

    }
}
