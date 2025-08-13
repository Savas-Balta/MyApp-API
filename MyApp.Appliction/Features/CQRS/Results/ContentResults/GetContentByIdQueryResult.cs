
namespace MyApp.Application.Features.CQRS.Results.Content
{
    public class GetContentByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
