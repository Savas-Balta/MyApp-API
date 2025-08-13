
namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetPublicContentsQueryHandler : IRequestHandler<GetPublicContentsQuery, List<ContentDto>>
    {
        private readonly IContentRepository _repository;

        public GetPublicContentsQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContentDto>> Handle(GetPublicContentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllContentsWithCategoryAndUserAsync();
        }
    }
}
