using Entities.Concrete.Data;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEtkinlikZiyaretDal:IBaseDal<EtkinlikZiyaret>
    {
        int GetByZiyaretId(int id);
        List<EtkinlikZiyaretDto> GetEtkinlikZiyaretDto();
        List<EtkinlikZiyaretDto> GetEtkinlikZiyaretByFirmaAdi(string firmaAdi);
    }
}
