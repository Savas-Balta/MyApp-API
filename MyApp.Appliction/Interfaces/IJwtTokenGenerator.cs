
namespace MyApp.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userName, string role, int userId);
    }
}
