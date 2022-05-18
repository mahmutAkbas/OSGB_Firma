using Entities.Concrete.Data;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUzmanYardimciDal : IBaseDal<Personel>
    {
        Task<int> DeleteAsync(Personel yardimci);
    }
}
