using Business.Utilities.Result.Abstract;
using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IYurutucuFirmaService:IBaseService<YurutucuFirma>
    {
        IDataResult<List<YurutucuFirma>> GetAllFilter(string adi);
    }
}
