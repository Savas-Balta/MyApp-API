
namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetContentQueryHandler : IRequestHandler<GetContentQuery, List<ContentDto>>
    {
        private readonly IContentRepository _repository;
        public GetContentQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContentDto>> Handle(GetContentQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllContentsWithCategoryAndUserAsync();
        }
    }
}
