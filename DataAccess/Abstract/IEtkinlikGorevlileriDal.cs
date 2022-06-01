using Entities.Concrete.Data;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEtkinlikGorevlileriDal:IBaseDal<EtkinlikGorevlileri>
    {
        List<EtkinlikGorevliDto> GetDtos(string personelAdi, int ziyaretId);

    }
}
