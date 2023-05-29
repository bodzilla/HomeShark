using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShark.Services.Contracts
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);
    }
}
