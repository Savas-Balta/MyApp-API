
namespace MyApp.Application.Interfaces
{
    public interface IContentRepository
    {
        Task<List<ContentDto>> GetAllContentsWithCategoryAndUserAsync();
        Task<List<ContentDto>> GetUserContentsWithCategoryAndUserAsync(int userId);
        Task<ContentDto?> GetPublicContentByIdAsync(int id);
        Task<GetContentByIdQueryResult> GetContentWithCategoryAndUserByIdAsync(int id);

    }
}
