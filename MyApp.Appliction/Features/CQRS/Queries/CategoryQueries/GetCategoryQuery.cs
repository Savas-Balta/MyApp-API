using MediatR;
using MyApp.Application.Features.CQRS.Results.CategoryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
    {
    }
}
