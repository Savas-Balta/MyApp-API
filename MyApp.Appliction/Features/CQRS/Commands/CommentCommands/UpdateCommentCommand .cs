using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
