using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.Repositories;

public interface IFoodRepository : IRepository<Food>
{
    Task<Food?> GetFoodByName(string foodName);
}