using MediatR;
using MyApp.Application.Dtos.ContentDtos;
using MyApp.Application.Features.CQRS.Results.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Queries.Content
{
    public class GetContentQuery : IRequest<List<ContentDto>> { }
    public class GetUserContentsQuery : IRequest<List<ContentDto>>
    {
        public int UserId { get; set; }
        public GetUserContentsQuery(int userId)
        {
            UserId = userId;
        }
    }
}
