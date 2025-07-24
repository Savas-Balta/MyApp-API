using MediatR;
using MyApp.Application.Features.CQRS.Results.UserResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.UserQueries
{
    public class GetUserQuery : IRequest<List<GetUserQueryResult>>
    {
    }
}
