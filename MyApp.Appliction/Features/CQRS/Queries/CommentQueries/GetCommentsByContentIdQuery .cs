
namespace MyApp.Application.Features.CQRS.Queries.CommentQueries
{
    public class GetCommentsByContentIdQuery : IRequest<List<GetCommentQueryResult>>
    {
        public int ContentId { get; set; }
        public GetCommentsByContentIdQuery(int contentId)
        {
            ContentId = contentId;
        }
    }
}
