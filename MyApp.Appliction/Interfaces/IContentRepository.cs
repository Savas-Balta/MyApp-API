using MyApp.Application.Dtos.ContentDtos;
using MyApp.Application.Features.CQRS.Results.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
