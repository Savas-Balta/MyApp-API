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
    public class GetPublicContentsQuery :  IRequest<List<ContentDto>>
    {
    }
}
