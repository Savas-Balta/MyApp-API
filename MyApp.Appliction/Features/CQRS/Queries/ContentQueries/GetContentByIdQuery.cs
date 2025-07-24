using MediatR;
using MyApp.Application.Features.CQRS.Results.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.Content
{
    public class GetContentByIdQuery : IRequest<GetContentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetContentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
