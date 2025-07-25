using MediatR;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Features.CQRS.Commands.CommentCommands;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand, Unit>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RemoveCommentCommandHandler(IRepository<Comment> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment =await _repository.GetByIdAsync(request.Id);

            if (comment == null)
            {
                throw new KeyNotFoundException("Yorum bulunamadı.");
            }

            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdStr, out var userId) || comment.Id != userId)
            {
                throw new UnauthorizedAccessException("Bu yorumu silemezsin.");
            }

            await _repository.RemoveAsync(comment);
            return Unit.Value;
        }
    }
}
