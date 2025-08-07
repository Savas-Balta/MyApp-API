using MediatR;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Dtos.ContentDtos;
using MyApp.Application.Features.CQRS.Queries.ContentQueries;
using MyApp.Application.Features.CQRS.Results.Content;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetMyContentsQueryHandler : IRequestHandler<GetMyContentsQuery, List<ContentDto>>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetMyContentsQueryHandler(IContentRepository contentRepository, IHttpContextAccessor httpContextAccessor)
        {
            _contentRepository = contentRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ContentDto>> Handle(GetMyContentsQuery request, CancellationToken cancellationToken)
        {
            var userIdFromToken = int.Parse(
                _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0"
            );

            return await _contentRepository.GetUserContentsWithCategoryAndUserAsync(userIdFromToken);
        }
    }
}
