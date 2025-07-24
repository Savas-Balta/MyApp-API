using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
