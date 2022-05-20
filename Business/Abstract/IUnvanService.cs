using Business.Utilities.Result.Abstract;
using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUnvanService:IBaseService<Unvan>
    {
        IDataResult<List<Unvan>> GetAllFilter(string unvanAdi);
    }
}
