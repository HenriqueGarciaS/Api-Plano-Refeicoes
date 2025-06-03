using APIPlanoDeReficoes.Context;
using APIPlanoDeReficoes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPlanoDeReficoes.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public async Task<User> GetUser(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == username && u.Password == password);
            return user;
        }
    }
}
