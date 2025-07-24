using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Commands.Content
{
    public class RemoveContentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public RemoveContentCommand(int id)
        {
            Id = id;
        }
    }
}
