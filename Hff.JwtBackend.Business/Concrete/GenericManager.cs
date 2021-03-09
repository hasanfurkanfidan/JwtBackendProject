using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.DataAccess.Abstract;
using Hff.JwtBackend.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.JwtBackend.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericManager(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _genericRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _genericRepository.DeleteAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericRepository.GetListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericRepository.UpdateAsync(entity);
        }
    }
}
