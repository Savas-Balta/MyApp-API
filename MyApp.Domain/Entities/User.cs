namespace MyApp.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; 

        public ICollection<Content>? Contents { get; set; }
        public ICollection<ContentVote>? Votes { get; set; }
    }
}
