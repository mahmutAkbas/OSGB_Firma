using Business.Utilities.Result.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRandevuService : IBaseService<Randevu>
    {
        IDataResult<List<Randevu>> GetAllByDate(DateTime tarih, int userId);
        IDataResult<List<Randevu>> GetAllById(int userId);
        IDataResult<List<RandevuDto>> GetRandevuDtoAllByOnay(bool randevuOnay);
        IDataResult<List<RandevuDto>> GetRandevuDtoAllFilter(DateTime randevuTarih, string firmaAdi, bool randevuOnay);
    }
}
