using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Common.Caching
{
    public static class CacheKeys
    {
        public static string ContentsAll => "contents:all";
        public static string UserContents(int userId) => $"contents:user:{userId}";
        public static string ContentById(int id) => $"contents:id:{id}";
        public static string CategoriesAll => "categories:all";
        public static string CategoryById(int id) => $"categories:id:{id}";
    }
}
