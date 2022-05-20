using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBaseDal<T>
    {
        int Add(T entity);
        int Delete(int id);
        int Update(T entity);
        T GetById(int id);      
        List<T> GetAll();
    }
}
