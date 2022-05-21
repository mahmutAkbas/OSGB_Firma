using Business.Utilities.Result.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEtkinlikZiyaretService : IBaseService<EtkinlikZiyaret>
    {
        IDataResult<int> AddCustom(EtkinlikZiyaret entity);
        IDataResult<List<EtkinlikZiyaretDto>> GetEtkinlikZiyaretDto();
       IDataResult<List<EtkinlikZiyaretDto>> GetEtkinlikZiyaretByFirmaAdi(string firmaAdi);

    }
}
