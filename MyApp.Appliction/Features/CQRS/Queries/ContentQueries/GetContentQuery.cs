using MediatR;
using MyApp.Application.Features.CQRS.Results.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.Content
{
    public class GetContentQuery : IRequest<List<GetContentQueryResult>>
    {
    }
}
