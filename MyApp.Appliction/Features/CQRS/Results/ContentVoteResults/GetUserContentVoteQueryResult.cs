using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Results.ContentVoteResults
{
    public class GetUserContentVoteQueryResult
    {
        public bool HasVoted { get; set; }
        public bool? IsLike { get; set; }
    }
}
