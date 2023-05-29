using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShark.Core.Contracts.Services
{
    public interface IService<TEntity, in TRequest1, in TRequest2>
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TRequest1 request);

        Task<TEntity> UpdateAsync(TRequest2 request);

        Task<TEntity> SetInactiveAsync(int id);
    }
}
