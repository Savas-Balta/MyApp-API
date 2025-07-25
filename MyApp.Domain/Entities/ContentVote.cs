using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class ContentVote
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int ContentId { get; set; }
        public Content? Content { get; set; }

        public bool IsLike { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
