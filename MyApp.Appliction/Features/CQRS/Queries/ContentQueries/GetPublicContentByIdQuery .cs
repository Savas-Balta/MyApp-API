
namespace MyApp.Application.Features.CQRS.Queries.ContentQueries
{
    public class GetPublicContentByIdQuery  : IRequest<ContentDto?>
    {
        public int Id { get; set; }
        public GetPublicContentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
