using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userName, string role, int userId);
    }
}
