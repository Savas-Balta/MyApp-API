using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Results.CommentResults
{
    public class GetCommentQueryResult
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ContentId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
