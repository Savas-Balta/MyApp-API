using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Commands.UserCommands
{
    public class RemoveUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public RemoveUserCommand(int id)
        {
            Id = id;
        }
    }
}
