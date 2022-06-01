using Entities.Concrete.Data;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEtkinlikGorevleriDal:IBaseDal<EtkinlikGorevleri>
    {
        List<EtkinlikGorevDto> GetEtkinlikGorevDtos(string islemAdi, int islemId);
    }
}
