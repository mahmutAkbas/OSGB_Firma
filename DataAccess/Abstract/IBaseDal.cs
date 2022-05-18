using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBaseDal<T>
    {
        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
