using Microsoft.EntityFrameworkCore;
using Practical_20.Model.Data;
using Practical_20.Repository.Interface;

namespace Practical_20.Repository.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                throw new Exception("Employee not found");
            }

            return entity;
        }

        public Task Update(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}
