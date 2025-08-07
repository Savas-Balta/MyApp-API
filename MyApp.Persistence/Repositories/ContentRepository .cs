using Microsoft.EntityFrameworkCore;
using MyApp.Application.Dtos.ContentDtos;
using MyApp.Application.Features.CQRS.Results.Content;
using MyApp.Application.Interfaces;
using MyApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly MyAppDbContext _context;

        public ContentRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContentDto>> GetAllContentsWithCategoryAndUserAsync()
        {
            return await _context.Contents
                .Include(c => c.Category)
                .Include(c => c.User)
                .Include(c => c.Votes)
                .Select(c => new ContentDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Body = c.Body,
                    CategoryName = c.Category.Name,
                    UserName = c.User.UserName,
                    CreatedAt = c.CreatedAt,
                    LikeCount = c.Votes.Count(v => v.IsLike == true),
                    DislikeCount = c.Votes.Count(v => v.IsLike == false)
                })
                .ToListAsync();
        }

        public async Task<List<ContentDto>> GetUserContentsWithCategoryAndUserAsync(int userId)
        {
            return await _context.Contents
                .Include(c => c.Category)
                .Include(c => c.User)
                .Include(c => c.Votes)
                .Where(c => c.UserId == userId)
                .Select(c => new ContentDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Body = c.Body,
                    CategoryName = c.Category.Name,
                    UserName = c.User.UserName,
                    CreatedAt = c.CreatedAt,
                    LikeCount = c.Votes.Count(v => v.IsLike == true),
                    DislikeCount = c.Votes.Count(v => v.IsLike == false)

                }).ToListAsync();
        }

        public async Task<ContentDto?> GetPublicContentByIdAsync(int id)
        {
            return await _context.Contents
                .Include(c => c.Category)
                .Include(c => c.User)
                .Where(c => c.Id == id && !c.IsDeleted)
                .Select(c => new ContentDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Body = c.Body,
                    CategoryName = c.Category.Name,
                    UserName = c.User.UserName,
                    CreatedAt = c.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<GetContentByIdQueryResult> GetContentWithCategoryAndUserByIdAsync(int id)
        {
            var content = await _context.Contents
                .Include(c => c.Category)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (content == null) return null;

            return new GetContentByIdQueryResult
            {
                Id = content.Id,
                Title = content.Title,
                Body = content.Body,
                UserId = content.UserId,
                UserName = content.User?.UserName,
                CategoryId = content.CategoryId,
                CategoryName = content.Category?.Name,
                IsDeleted = content.IsDeleted,
                CreatedAt = content.CreatedAt
            };
        }
    }
}
