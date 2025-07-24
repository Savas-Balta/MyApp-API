using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
