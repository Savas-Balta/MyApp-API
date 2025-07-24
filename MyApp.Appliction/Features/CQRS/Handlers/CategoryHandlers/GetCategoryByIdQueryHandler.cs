using MediatR;
using MyApp.Application.Features.CQRS.Queries.CategoryQueries;
using MyApp.Application.Features.CQRS.Results.CategoryResults;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetCategoryByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
            };
        }
    }
}
