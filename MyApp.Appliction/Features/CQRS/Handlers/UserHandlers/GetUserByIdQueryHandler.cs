using MediatR;
using MyApp.Application.Features.CQRS.Queries.UserQueries;
using MyApp.Application.Features.CQRS.Results.UserResults;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetUserByIdQueryResult
            {
                Id = value.Id,
                UserName = value.UserName,
                Role = value.Role
            };
        }
    }
}
