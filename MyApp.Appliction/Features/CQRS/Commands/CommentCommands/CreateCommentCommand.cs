using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Commands.CommentCommands
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Text { get; set; } = string.Empty;
        public int ContentId { get; set; }
    }
}
