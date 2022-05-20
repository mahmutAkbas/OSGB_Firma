using Entities.Concrete.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnvanDal : IBaseDal<Unvan>
    {
        List<Unvan> GetAllFilter(Unvan unvan);
    }
}
