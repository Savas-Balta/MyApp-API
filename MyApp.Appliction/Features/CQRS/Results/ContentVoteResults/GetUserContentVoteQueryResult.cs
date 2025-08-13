
namespace MyApp.Application.Features.CQRS.Results.ContentVoteResults
{
    public class GetUserContentVoteQueryResult
    {
        public bool HasVoted { get; set; }
        public bool? IsLike { get; set; }
    }
}
