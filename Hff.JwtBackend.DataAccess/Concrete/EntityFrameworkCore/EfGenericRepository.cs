using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.JwtBackend.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, ITable, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new Context();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new Context();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            using var context = new Context();
            return await context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var context = new Context();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            using var context = new Context();
            if (expression != null)
            {
                return await context.Set<TEntity>().Where(expression).ToListAsync();
            }
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new Context();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
