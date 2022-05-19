using Business.Utilities.Result.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T>
    {
        Task<IDataResult<int>> Add(T entity);
        Task<IDataResult<int>> Update(T entity);
        Task<IDataResult<T>> GetById(int id);
        Task<IDataResult<int>> Delete(T entity);
        Task<IDataResult<List<T>>> GetAll();
    }
}
