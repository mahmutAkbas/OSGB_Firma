using Business.Utilities.Result.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEtkinlikGorevlileriService:IBaseService<EtkinlikGorevlileri>
    {
        IDataResult<List<EtkinlikGorevliDto>> GetDtos(string personelAdi);
    }
}
