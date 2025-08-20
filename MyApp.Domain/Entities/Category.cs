namespace MyApp.Domain.Entities
{
    public class Category : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Content>? Contents { get; set; }
    }
}
