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
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetCategoryQueryResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
