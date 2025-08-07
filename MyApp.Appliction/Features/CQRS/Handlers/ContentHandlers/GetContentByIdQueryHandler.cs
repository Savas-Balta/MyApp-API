using MediatR;
using MyApp.Application.Features.CQRS.Queries.Content;
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
    public class GetContentByIdQueryHandler : IRequestHandler<GetContentByIdQuery, GetContentByIdQueryResult>
    {
        private readonly IContentRepository _repository;

        public GetContentByIdQueryHandler(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetContentByIdQueryResult> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetContentWithCategoryAndUserByIdAsync(request.Id);
        }
    }
}
