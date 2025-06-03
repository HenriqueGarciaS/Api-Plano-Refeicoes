using APIPlanoDeReficoes.Context;
using APIPlanoDeReficoes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPlanoDeReficoes.Repositories
{
    public class Repository <T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAll(int page)
        {
            int pageSize = 20;
            if (page - 1 <= 0)
                return await _context.Set<T>().AsNoTracking().Take(pageSize).ToListAsync();
            return await _context.Set<T>().AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Create(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<T> Update(T model)
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<T> DeleteById(int id)
        {
            var model = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
