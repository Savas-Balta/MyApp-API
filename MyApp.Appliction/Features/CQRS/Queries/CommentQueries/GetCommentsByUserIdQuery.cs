using MediatR;
using MyApp.Application.Features.CQRS.Results.CommentResults;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.CommentQueries
{
    public class GetCommentsByUserIdQuery : IRequest<List<GetCommentQueryResult>>
    {
        public int UserId { get; set; }

        public GetCommentsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
