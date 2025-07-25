using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Commands.CommentCommands
{
    public class RemoveCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public RemoveCommentCommand(int id)
        {
            Id = id;
        }
    }
}
