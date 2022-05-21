using Entities.Concrete.Data;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRandevuDal:IBaseDal<Randevu>
    {
        List<Randevu> GetAllByDate(DateTime tarih,int userId);
        List<Randevu> GetAllById( int userId);
        List<RandevuDto> GetlRandevuDtoAll(bool randevuOnay);
        List<RandevuDto> GetlRandevuDtoFilter(DateTime randevuTarih,string firmaAdi,bool randevuOnay);
    }
}
