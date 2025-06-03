using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUser(string username, string password);
    }
}
