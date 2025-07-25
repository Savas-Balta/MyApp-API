using MediatR;
using MyApp.Application.Features.CQRS.Results.ContentVoteResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.ContentVoteQueries
{
    public class GetUserContentVoteQuery : IRequest<GetUserContentVoteQueryResult>
    {
        public int ContentId { get; set; }

        public GetUserContentVoteQuery(int contentId)
        {
            ContentId = contentId;
        }
    }
}
