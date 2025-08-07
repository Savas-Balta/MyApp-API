using MediatR;
using MyApp.Application.Dtos.ContentDtos;
using MyApp.Application.Features.CQRS.Queries.ContentQueries;
using MyApp.Application.Features.CQRS.Results.Content;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class GetPublicContentsQueryHandler : IRequestHandler<GetPublicContentsQuery, List<ContentDto>>
    {
        private readonly IContentRepository _repository;

        public GetPublicContentsQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContentDto>> Handle(GetPublicContentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllContentsWithCategoryAndUserAsync();
        }
    }
}
