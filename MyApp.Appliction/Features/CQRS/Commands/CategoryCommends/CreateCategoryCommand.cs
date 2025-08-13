
namespace MyApp.Application.Features.CQRS.Commands.CategoryCommends
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
    }
}
