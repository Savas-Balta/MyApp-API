using MediatR;
using MyApp.Application.Features.CQRS.Commands.UserCommands;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.UserHandlers
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Unit>
    {
        private readonly IRepository<User> _repository;

        public RemoveUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
            return Unit.Value;
        }
    }
}
