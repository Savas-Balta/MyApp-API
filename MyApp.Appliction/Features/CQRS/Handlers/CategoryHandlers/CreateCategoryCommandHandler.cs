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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Category
            {
                Name = request.Name,
            });
            return Unit.Value;
        }
    }
}
