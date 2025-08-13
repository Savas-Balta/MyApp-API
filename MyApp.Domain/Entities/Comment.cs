
namespace MyApp.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public int ContentId { get; set; }
        public Content? Content { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
