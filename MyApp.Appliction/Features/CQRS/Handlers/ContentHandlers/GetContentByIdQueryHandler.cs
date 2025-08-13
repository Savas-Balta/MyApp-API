
namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetContentByIdQueryHandler : IRequestHandler<GetContentByIdQuery, GetContentByIdQueryResult>
    {
        private readonly IContentRepository _repository;

        public GetContentByIdQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetContentByIdQueryResult> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetContentWithCategoryAndUserByIdAsync(request.Id);
        }
    }
}
