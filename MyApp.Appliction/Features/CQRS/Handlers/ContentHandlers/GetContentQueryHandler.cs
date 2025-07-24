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
    public class GetContentQueryHandler : IRequestHandler<GetContentQuery, List<GetContentQueryResult>>
    {
        private readonly IRepository<Content> _repository;

        public GetContentQueryHandler(IRepository<Content> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContentQueryResult>> Handle(GetContentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContentQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Body = x.Body,
                UserId = x.UserId,
                CategoryId = x.CategoryId,
                IsDeleted = x.IsDeleted,
                CreatedAt = x.CreatedAt
            }).ToList();
        }
    }
}
