
namespace MyApp.Application.Features.CQRS.Queries.CommentQueries
{
    public class GetCommentsByUserIdQuery : IRequest<List<GetCommentQueryResult>>
    {
        public int UserId { get; set; }

        public GetCommentsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
