using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Commands.ContentVoteCommands
{
    public class CreateContentVoteCommand : IRequest<Unit>
    {
        public int ContentId { get; set; }
        public bool IsLike { get; set; }
    }
}
