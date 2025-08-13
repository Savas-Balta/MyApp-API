
namespace MyApp.Application.Features.CQRS.Results.UserResults
{
    public class GetUserByIdQueryResult
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
