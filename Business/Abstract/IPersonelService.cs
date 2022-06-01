using Business.Utilities.Result.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelService:IBaseService<Personel>
    {
        IDataResult<List<PersonelDto>> GetAllPersonelDto(bool silinmeDurumu);
        IDataResult<List<PersonelDto>> GetAllFilter(string personelAdi,bool silinmeDurumu);

    }
}
