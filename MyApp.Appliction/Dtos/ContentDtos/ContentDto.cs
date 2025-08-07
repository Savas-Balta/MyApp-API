using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Dtos.ContentDtos
{
    public class ContentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}
