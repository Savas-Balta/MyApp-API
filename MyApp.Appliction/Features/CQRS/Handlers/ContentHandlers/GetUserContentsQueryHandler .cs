
namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetUserContentsQueryHandler : IRequestHandler<GetUserContentsQuery, List<ContentDto>>
    {
        private readonly IContentRepository _repository;
        public GetUserContentsQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContentDto>> Handle(GetUserContentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserContentsWithCategoryAndUserAsync(request.UserId);
        }
    }
}
