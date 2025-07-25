using MediatR;
using MyApp.Application.Features.CQRS.Results.CommentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.CommentQueries
{
    public class GetCommentsByContentIdQuery : IRequest<List<GetCommentQueryResult>>
    {
        public int ContentId { get; set; }
        public GetCommentsByContentIdQuery(int contentId)
        {
            ContentId = contentId;
        }
    }
}
