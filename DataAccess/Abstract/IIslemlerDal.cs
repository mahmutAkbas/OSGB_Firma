using Entities.Concrete.Data;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IIslemlerDal : IBaseDal<Islemler>
    {
        List<Islemler> GetAllFilter(string islemAdi);
    }
}
