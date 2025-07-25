using MediatR;
using MyApp.Application.Features.CQRS.Queries.CommentQueries;
using MyApp.Application.Features.CQRS.Results.CommentResults;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class GetCommentsByUserIdQueryHandler : IRequestHandler<GetCommentsByUserIdQuery, List<GetCommentQueryResult>>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentsByUserIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetAllAsync();
            return comments
                .Where(x => x.UserId == request.UserId)
                .Select(x => new GetCommentQueryResult
                {
                    Id = x.Id,
                    Text = x.Text,
                    UserId = x.UserId,
                    ContentId = x.ContentId,
                    CreatedAt = x.CreatedAt
                })
                .ToList();
        }
    }
}
