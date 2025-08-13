
namespace MyApp.Application.Features.CQRS.Queries.Content
{
    public class GetContentByIdQuery : IRequest<GetContentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetContentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
