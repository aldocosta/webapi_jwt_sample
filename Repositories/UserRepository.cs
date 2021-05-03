using System.Linq;
using System.Threading.Tasks;
using codeFirsto.Models;
using codeFirsto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace codeFirsto.Repositories
{
    public class UserRepository : IUserRepository
    {
        private BookStoreDBContext _context;
        public UserRepository(BookStoreDBContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser(string name, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.UserName == name && p.Password == password);
        }
    }
}