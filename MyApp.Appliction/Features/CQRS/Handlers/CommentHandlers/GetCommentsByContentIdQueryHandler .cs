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
    public class GetCommentsByContentIdQueryHandler : IRequestHandler<GetCommentsByContentIdQuery, List<GetCommentQueryResult>>
    {
        private readonly IRepository<Comment> _repository;
        public GetCommentsByContentIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCommentQueryResult>> Handle(GetCommentsByContentIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetAllAsync();

            return comments
                .Where(x => x.ContentId == request.ContentId)
                .Select(x => new GetCommentQueryResult
                {
                    Id = x.Id,
                    Text = x.Text,
                    ContentId = x.ContentId,
                    UserId = x.UserId,
                    CreatedAt = x.CreatedAt
                }).ToList();
        }
    }
}
