using MediatR;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Features.CQRS.Commands.ContentVoteCommands;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.ContentVoteHandlers
{
    public class CreateContentVoteCommandHandler : IRequestHandler<CreateContentVoteCommand, Unit>
    {
        private readonly IRepository<ContentVote> _repository;
        private readonly IRepository<Content> _contentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateContentVoteCommandHandler(IRepository<ContentVote> repository, IRepository<Content> contentRepository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _contentRepository = contentRepository;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<Unit> Handle(CreateContentVoteCommand request, CancellationToken cancellationToken)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out var userIdFromToken) || userIdFromToken <= 0)
            {
                throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");
            }

            var existingVote = await _repository.GetByFilterAsync(x =>
                x.UserId == userIdFromToken && x.ContentId == request.ContentId);

            if (existingVote == null)
            {
                await _repository.CreateAsync(new ContentVote
                {
                    ContentId = request.ContentId,
                    UserId = userIdFromToken,
                    IsLike = request.IsLike
                });
            }
            else
            {
                existingVote.IsLike = request.IsLike;
                await _repository.UpdateAsync(existingVote);
            }

            return Unit.Value;
        }
    }
}
