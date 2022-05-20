using Entities.Concrete.Data;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUzmanYardimciDal : IBaseDal<Personel>
    {
        int Delete(Personel yardimci);
    }
}
