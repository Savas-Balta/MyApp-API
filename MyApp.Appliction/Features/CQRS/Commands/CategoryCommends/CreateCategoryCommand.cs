using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Commands.CategoryCommends
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
    }
}
