
namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetPublicContentByIdQueryHandler : IRequestHandler<GetPublicContentByIdQuery, ContentDto?>
    {
        private readonly IContentRepository _repository;

        public GetPublicContentByIdQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContentDto?> Handle(GetPublicContentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPublicContentByIdAsync(request.Id);
        }
    }
}
