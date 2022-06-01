using Entities.Concrete.Data;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonelDal : IBaseDal<Personel>
    {
        List<PersonelDto> GetAllPersonelDto(bool silinmeDurumu);
        List<PersonelDto> GetAllFilter(string personelAdi,bool silinmeDurumu);
        

    }
}
