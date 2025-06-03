﻿namespace APIPlanoDeReficoes.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T Create(T model);
        T Update(T model);
        T DeleteById(int id);
    }
}
