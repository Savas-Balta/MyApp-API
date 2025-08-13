
namespace MyApp.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateCommentCommandHandler(IHttpContextAccessor httpContextAccessor, IRepository<Comment> repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);
            if (comment == null)
                throw new Exception("Yorum bulunamadı");

            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdStr, out var userId) || comment.UserId != userId)
                throw new UnauthorizedAccessException("Bu yorumu güncelleyemezsiniz.");

            comment.Text = request.Text;
            await _repository.UpdateAsync(comment);

            return Unit.Value;
        }
    }
}
