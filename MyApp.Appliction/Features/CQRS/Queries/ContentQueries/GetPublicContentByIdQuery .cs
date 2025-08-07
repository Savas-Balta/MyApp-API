using MediatR;
using MyApp.Application.Dtos.ContentDtos;
using MyApp.Application.Features.CQRS.Results.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.ContentQueries
{
    public class GetPublicContentByIdQuery  : IRequest<ContentDto?>
    {
        public int Id { get; set; }
        public GetPublicContentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
