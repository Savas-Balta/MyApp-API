using MediatR;
using MyApp.Application.Dtos.ContentDtos;
using MyApp.Application.Features.CQRS.Queries.Content;
using MyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetUserContentsQueryHandler : IRequestHandler<GetUserContentsQuery, List<ContentDto>>
    {
        private readonly IContentRepository _repository;
        public GetUserContentsQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContentDto>> Handle(GetUserContentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserContentsWithCategoryAndUserAsync(request.UserId);
        }
    }
}
