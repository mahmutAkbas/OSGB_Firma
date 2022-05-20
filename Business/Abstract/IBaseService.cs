using Business.Utilities.Result.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T>
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IDataResult<T> GetById(int id);
        IResult Delete(T entity);
        IDataResult<List<T>> GetAll();
       
    }
}
