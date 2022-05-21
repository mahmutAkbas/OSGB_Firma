using Business.Utilities.Result.Abstract;
using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IIslemlerService:IBaseService<Islemler>
    {
        IDataResult<List<Islemler>> GetAllFilter(string islemAdi);
    }
}
