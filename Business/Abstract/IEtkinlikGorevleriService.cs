using Business.Utilities.Result.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEtkinlikGorevleriService : IBaseService<EtkinlikGorevleri>
    {
        IDataResult<List<EtkinlikGorevDto>> GetEtkinlikGorevDtos(string islemAdi, int ziyaretId);

    }
}
