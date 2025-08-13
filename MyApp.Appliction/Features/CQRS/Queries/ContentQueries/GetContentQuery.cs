
namespace MyApp.Application.Features.CQRS.Queries.Content
{
    public class GetContentQuery : IRequest<List<ContentDto>> { }
    public class GetUserContentsQuery : IRequest<List<ContentDto>>
    {
        public int UserId { get; set; }
        public GetUserContentsQuery(int userId)
        {
            UserId = userId;
        }
    }
}
