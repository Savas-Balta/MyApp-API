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
    public class GetPublicContentByIdQueryHandler : IRequestHandler<GetPublicContentByIdQuery, ContentDto?>
    {
        private readonly IContentRepository _repository;

        public GetPublicContentByIdQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContentDto?> Handle(GetPublicContentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPublicContentByIdAsync(request.Id);
        }
    }
}
