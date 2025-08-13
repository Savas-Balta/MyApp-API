
namespace MyApp.Application.Features.CQRS.Queries.ContentVoteQueries
{
    public class GetUserContentVoteQuery : IRequest<GetUserContentVoteQueryResult>
    {
        public int ContentId { get; set; }

        public GetUserContentVoteQuery(int contentId)
        {
            ContentId = contentId;
        }
    }
}
