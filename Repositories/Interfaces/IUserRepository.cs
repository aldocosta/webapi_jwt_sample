using System.Threading.Tasks;
using codeFirsto.Models;

namespace codeFirsto.Repositories.Interfaces
{
    public interface IUserRepository
    {
         Task<User> GetUser(string name, string password);
    }
}