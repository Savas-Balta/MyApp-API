
namespace MyApp.Application.Features.CQRS.Commands.CategoryCommends
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
