using codeFirsto.Models;

namespace codeFirsto.Services.Interfaces
{
    public interface ITokenServices
    {
         string GenerateToken(User user);
    }
}