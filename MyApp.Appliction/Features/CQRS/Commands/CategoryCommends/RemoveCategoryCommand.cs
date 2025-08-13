
namespace MyApp.Application.Features.CQRS.Commands.CategoryCommends
{
    public class RemoveCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
