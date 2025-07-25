using MediatR;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Features.CQRS.Queries.ContentVoteQueries;
using MyApp.Application.Features.CQRS.Results.ContentVoteResults;
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
    public class GetUserContentVoteQueryHandler : IRequestHandler<GetUserContentVoteQuery, GetUserContentVoteQueryResult>
    {
        private readonly IRepository<ContentVote> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserContentVoteQueryHandler(IHttpContextAccessor httpContextAccessor, IRepository<ContentVote> repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<GetUserContentVoteQueryResult> Handle(GetUserContentVoteQuery request, CancellationToken cancellationToken)
        {
            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (!int.TryParse(userIdStr, out var userId) || userId <= 0)
            {
                throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");
            }
            var Vote =await _repository.GetByFilterAsync(x => x.UserId == userId && x.ContentId == request.ContentId);

            return Vote != null 
                ? new GetUserContentVoteQueryResult { HasVoted = true, IsLike = Vote.IsLike }
                : new GetUserContentVoteQueryResult { HasVoted = false, IsLike = null };
        }
    }
}
