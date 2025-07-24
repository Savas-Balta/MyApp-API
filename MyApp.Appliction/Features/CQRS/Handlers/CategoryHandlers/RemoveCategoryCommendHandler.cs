using MediatR;
using MyApp.Application.Features.CQRS.Commands.CategoryCommends;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommendHandler : IRequestHandler<RemoveCategoryCommand, Unit>
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommendHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
            return Unit.Value;
        }
    }
}
