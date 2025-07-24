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
        private readonly IRepository<Content> _repository;

        public GetContentByIdQueryHandler(IRepository<Content> repository)
        {
            _repository = repository;
        }

        public async Task<GetContentByIdQueryResult> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetContentByIdQueryResult
            {
                Id = value.Id,
                Title = value.Title,
                Body = value.Body,
                UserId = value.UserId,
                CategoryId = value.CategoryId,
                IsDeleted = value.IsDeleted,
                CreatedAt = value.CreatedAt
            };
        }
    }
}
