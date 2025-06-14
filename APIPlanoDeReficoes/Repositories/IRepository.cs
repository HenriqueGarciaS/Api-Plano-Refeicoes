﻿namespace APIPlanoDeReficoes.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll(int page);
        Task<T?> GetById(int id);
        Task<T> Create(T model);
        Task<T> Update(T model);
        Task<T> DeleteById(int id);
    }
}
